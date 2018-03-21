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
using Newtonsoft.Json;
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
        public PoliceCommonHub(IOnlineClientManager onlineClientManager, ChatHistoryManager chatHistoryManager,
            ChatMessageManager chatMessageManager, ChatGroupManager chatGroupManager, UserManager userManager) : base(
            onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;
            _chatHistoryManager = chatHistoryManager;
            _chatMessageManager = chatMessageManager;
            _chatGroupManager = chatGroupManager;
            _userManager = userManager;
        }

        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <returns></returns>
        public async Task GetHistories()
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                // 查询历史记录
                var chatMessages = await _chatHistoryManager.GetChatHistoryAsync(AbpSession.ToUserIdentifier());
                var chatMessageDto = chatMessages.MapTo<List<ChatMessageReceiveDto>>();
                Clients.Client(Context.ConnectionId).getMessages(chatMessageDto);
            }
        }

        #region 消息相关

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <returns></returns>
        public async Task<ChatMessageReceiveDto> SendMessage(string sendMessage)
        {
            ChatMessageSendDto chatMessageSendDto = JsonConvert.DeserializeObject<ChatMessageSendDto>(sendMessage);
            using (var uow = UnitOfWorkManager.Begin())
            {
                if (chatMessageSendDto.ToUserId == 0)
                {
                    chatMessageSendDto.ToUserId = null;
                }
                if (chatMessageSendDto.ToGroupId == 0)
                {
                    chatMessageSendDto.ToGroupId = null;
                }
                var chatMessage = chatMessageSendDto.MapTo<ChatMessage>();

                chatMessage = await _chatMessageManager.AddMessageAsync(chatMessage);

                var chatMessageReceiveDto = chatMessage.MapTo<ChatMessageReceiveDto>();

                chatMessageReceiveDto.FromUser =
                    (await _userManager.GetUserByIdAsync(chatMessageReceiveDto.CreatorUserId.Value))
                    .MapTo<UserSimpleDto>();

                if (chatMessageReceiveDto.ChatSendType == ChatSendType.Group)
                {
                    chatMessageReceiveDto.ToGroup =
                        (await _chatGroupManager.GetGroupByIdAsync(chatMessageReceiveDto.ToGroupId.Value))
                        .MapTo<ChatMessageGroupDto>();
                    Clients.Group(chatMessageReceiveDto.ToGroup.Name).getMessage(chatMessageReceiveDto);
                }
                else
                {
                    chatMessageReceiveDto.ToUser =
                        (await _userManager.GetUserByIdAsync(chatMessageReceiveDto.ToUserId.Value))
                        .MapTo<UserSimpleDto>();
                    var clients = _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId,
                        chatMessageReceiveDto.ToUserId.Value));
                    foreach (var onlineClient in clients)
                    {
                        Clients.Client(onlineClient.ConnectionId).getMessage(chatMessageReceiveDto);
                    }
                }

                await uow.CompleteAsync();
                return chatMessage.MapTo<ChatMessageReceiveDto>();
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="messageIds"></param>
        /// <returns></returns>
        public async Task ReadMessages(string messageIdStr)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                List<EntityDto<long>> messageIds = JsonConvert.DeserializeObject<List<EntityDto<long>>>(messageIdStr);
                await _chatHistoryManager.ReadMessagesAsync(AbpSession.ToUserIdentifier(),
                    messageIds.Select(p => p.Id).ToList());
                await uow.CompleteAsync();
            }
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
            using (var uow = UnitOfWorkManager.Begin())
            {
                try
                {
                    var chatGroup = await _chatGroupManager.CreateGroupAsync(AbpSession.ToUserIdentifier(), groupName);
                    await Groups.Add(Context.ConnectionId, chatGroup.Name);
                }
                catch (UserFriendlyException e)
                {
                    Clients.Client(Context.ConnectionId).showError(e.Message);
                    return;
                }

                await uow.CompleteAsync();

                await JoinGroups();
            }
        }

        /// <summary>
        /// 登录后加入本人所有群组
        /// </summary>
        /// <returns></returns>
        public async Task JoinGroups()
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var chatGroups = await _chatGroupManager.GetGroupsAsync(AbpSession.ToUserIdentifier());
                foreach (var chatGroup in chatGroups)
                {
                    await Groups.Add(Context.ConnectionId, chatGroup.Name);
                }
                Clients.Client(Context.ConnectionId).joinGroups(chatGroups.MapTo<List<ChatGroupDto>>());

                await uow.CompleteAsync();
            }
        }

        /// <summary>
        /// 邀请加入群组
        /// </summary>
        /// <returns></returns>
        public async Task InviteToGroup(string inputStr)
        {
            Logger.Info("开始拉人" + inputStr);
            InviteToGroupInput input = JsonConvert.DeserializeObject<InviteToGroupInput>(inputStr);
            Logger.Info("序列化完成");
            using (var uow = UnitOfWorkManager.Begin())
            {
                Logger.Info("开始");
                var chatGroup =
                    await _chatGroupManager.InviteToGroupAsync(input.GroupId,
                        input.UserIds);

                await uow.CompleteAsync();
                await JoinGroups();
                Logger.Info("通知本人完成");

                Logger.Info("返回，遍历在线用户发送通知");
                foreach (var inputUserId in input.UserIds)
                {
                    var allByUserId =
                        _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId, inputUserId));
                    Logger.Info($"获取到{inputUserId}的在线列表：" + allByUserId.Count);
                    foreach (var onlineClient in allByUserId)
                    {
                        Logger.Info("遍历用户");
                        try
                        {
                            await Groups.Add(onlineClient.ConnectionId, chatGroup.Name);
                        }
                        catch (Exception e)
                        {
                            Logger.Error(e.Message);
                        }

                        Logger.Info("加入群组完成");
                        // 通知其他用户加入群组

                        Clients.Client(onlineClient.ConnectionId).joinGroup(chatGroup.MapTo<ChatGroupDto>());
                        Logger.Info("发送加入群组完成");
                    }
                }
                Logger.Info("完成");
            }
        }

        /// <summary>
        /// 删除群组
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public async Task DeleteGroup(string inputStr)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                EntityDto<long> groupId = JsonConvert.DeserializeObject<EntityDto<long>>(inputStr);
                var chatGroup = await _chatGroupManager.DeleteGroupAsync(groupId.Id);
                await uow.CompleteAsync();

                Clients.Group(chatGroup.Name).deleteGroup(chatGroup.MapTo<ChatGroupDto>());
            }
        }

        public async Task ExitGroup(string inputStr)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                ExitGroupInput input = JsonConvert.DeserializeObject<ExitGroupInput>(inputStr);
                var chatGroup = await _chatGroupManager.ExitGroupAsync(input.GroupId, input.UserId);
                await uow.CompleteAsync();

                foreach (var onlineClient in _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId, input.UserId)))
                {
                    Clients.Client(onlineClient.ConnectionId).deleteGroup(chatGroup.MapTo<ChatGroupDto>());
                }
                Clients.Group(chatGroup.Name).deleteUser(input);
            }

        }

        #endregion
    }
}