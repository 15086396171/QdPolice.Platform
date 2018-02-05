using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.Web.SignalR.Hubs;
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
            var chatMessage = chatMessageSendDto.MapTo<ChatMessage>();

            chatMessage = await _chatMessageManager.AddMessageAsync(chatMessage);

            var chatMessageReceiveDto = chatMessage.MapTo<ChatMessageReceiveDto>();

            chatMessageReceiveDto.FromUser =
                (await _userManager.GetUserByIdAsync(chatMessageReceiveDto.CreatorUserId.Value)).MapTo<UserSimpleDto>();

            if (chatMessageReceiveDto.ChatSendType == ChatSendType.Group)
            {
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
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="messageIds"></param>
        /// <returns></returns>
        public async Task ReadMessages(List<EntityDto<long>> messageIds)
        {
            await _chatHistoryManager.ReadMessagesAsync(AbpSession.ToUserIdentifier(), messageIds.Select(p=>p.Id).ToList());
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
            var chatGroup = await _chatGroupManager.CreateGroupAsync(groupName);

            await Groups.Add(Context.ConnectionId, chatGroup.Name);
        }

        #endregion
    }
}