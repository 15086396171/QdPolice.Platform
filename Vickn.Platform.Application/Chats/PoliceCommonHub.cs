using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.SignalR.Hubs;
using Vickn.Platform.Chats.ChatGroups.Dtos;
using Vickn.Platform.Chats.ChatGroupUsers.Dtos;
using Vickn.Platform.Chats.ChatMessages;
using Vickn.Platform.Users;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 集中hub管理
    /// </summary>
    [UnitOfWork]
    public class PoliceCommonHub : AbpCommonHub
    {
        private readonly ChatHistoryManager _chatHistoryManager;
        private readonly ChatMessageManager _chatMessageManager;
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly ChatGroupManager _chatGroupManager;
        private readonly UserManager _userManager;

        public IUnitOfWorkManager UnitOfWorkManager { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Abp.Web.SignalR.Hubs.AbpCommonHub" /> class.
        /// </summary>
        public PoliceCommonHub(IOnlineClientManager onlineClientManager, ChatHistoryManager chatHistoryManager, ChatMessageManager chatMessageManager, ChatGroupManager chatGroupManager, UserManager userManager) : base(onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;
            _chatHistoryManager = chatHistoryManager;
            _chatMessageManager = chatMessageManager;
            _chatGroupManager = chatGroupManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Called when the connection connects to this hub instance.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /></returns>

        public override async Task OnConnected()
        {
            await base.OnConnected();
            await JoinGroups();
            await GetHistories();
        }

        private async Task GetHistories()
        {
            // 查询历史记录
            var chatMessages = await _chatHistoryManager.GetChatHistoryAsync(AbpSession.ToUserIdentifier());
            var chatMessageDto = chatMessages.MapTo<List<ChatMessageReceiveDto>>();

            var clients = _onlineClientManager.GetAllByUserId(AbpSession.ToUserIdentifier());
            foreach (var onlineClient in clients)
            {
                Clients.Client(onlineClient.ConnectionId).getMessages(chatMessageDto);
            }
        }

        /// <summary>
        /// Called when the connection reconnects to this hub instance.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /></returns>
        public override async Task OnReconnected()
        {
            await base.OnReconnected();
            await JoinGroups();
            await GetHistories();
        }

        #region 消息相关

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="chatMessageSendDto"></param>
        /// <returns></returns>
        public async Task SendMessage(ChatMessageSendDto chatMessageSendDto)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var chatMessage = chatMessageSendDto.MapTo<ChatMessage>();

                chatMessage = await _chatMessageManager.AddMessageAsync(chatMessage);

                var chatMessageReceiveDto = chatMessage.MapTo<ChatMessageReceiveDto>();

                chatMessageReceiveDto.FromUser =
                    (await _userManager.GetUserByIdAsync(chatMessageReceiveDto.CreatorUserId.Value)).MapTo<UserSimpleDto>();

                if (chatMessageReceiveDto.ChatSendType == ChatSendType.Group)
                {
                    chatMessageReceiveDto.ToGroup =
                        (await _chatGroupManager.GetGroupByIdAsync(chatMessageReceiveDto.ToGroupId.Value))
                        .MapTo<ChatGroupDto>();
                    Clients.Group(chatMessageReceiveDto.ToGroup.Name).getMessage(chatMessageReceiveDto);
                }
                else
                {
                    chatMessageReceiveDto.ToUser =
                        (await _userManager.GetUserByIdAsync(chatMessageReceiveDto.ToUserId.Value)).MapTo<UserSimpleDto>();
                    var clients = _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId, chatMessageReceiveDto.ToUserId.Value));
                    foreach (var onlineClient in clients)
                    {
                        Clients.Client(onlineClient.ConnectionId).getMessage(chatMessageReceiveDto);
                    }
                }

                await uow.CompleteAsync();
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="messageIds"></param>
        /// <returns></returns>
        public async Task ReadMessages(List<EntityDto<long>> messageIds)
        {
            await _chatHistoryManager.ReadMessagesAsync(AbpSession.ToUserIdentifier(), messageIds.Select(p => p.Id).ToList());
        }

        #endregion

        #region 群组相关

        /// <summary>
        /// 创建群组
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public async Task CreateGroup(string groupName)
        {
            try
            {
                var chatGroup = await _chatGroupManager.CreateGroupAsync(AbpSession.ToUserIdentifier(), groupName);
                await Groups.Add(Context.ConnectionId, chatGroup.Name);
            }
            catch (UserFriendlyException e)
            {
                Clients.Client(Context.ConnectionId).showError(e.Message);
            }
            await JoinGroups();
        }

        /// <summary>
        /// 登录后加入本人所有群组
        /// </summary>
        /// <returns></returns>
        public async Task JoinGroups()
        {
            var chatGroups = await _chatGroupManager.GetGroupsAsync(AbpSession.ToUserIdentifier());
            foreach (var chatGroup in chatGroups)
            {
                await Groups.Add(Context.ConnectionId, chatGroup.Name);
            }
            Clients.Client(Context.ConnectionId).joinGroups(chatGroups.MapTo<List<ChatGroupDto>>());
        }

        /// <summary>
        /// 邀请加入群组
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChatGroupUserDto>> InviteToGroup(InviteToGroupInput input)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var chatGroup =
                    await _chatGroupManager.InviteToGroupAsync(input.GroupId,
                        input.UserIds.Select(p => p.Id).ToList());
                foreach (var inputUserId in input.UserIds)
                {
                    var allByUserId =
                        _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId, inputUserId.Id));
                    foreach (var onlineClient in allByUserId)
                    {
                        await Groups.Add(onlineClient.ConnectionId, chatGroup.Name);
                        // 通知其他用户加入群组
                        Clients.Client(onlineClient.ConnectionId).joinGroup(chatGroup.MapTo<ChatGroupDto>());
                    }
                }
                await uow.CompleteAsync();
                return await GetGroupUsers(input.GroupId);
            }
        }

        /// <summary>
        /// 获取组织用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChatGroupUserDto>> GetGroupUsers(long groupId)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var chatGroupUsers = await _chatGroupManager.GetChatGroupUsers(groupId);
                var chatGroupUserDtos = chatGroupUsers.MapTo<List<ChatGroupUserDto>>();
                return chatGroupUserDtos;
            }
        }

        #endregion
    }
}