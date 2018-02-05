using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.Web.SignalR.Hubs;
using Vickn.Platform.Chats.ChatMessages;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 集中hub管理
    /// </summary>
    public class PoliceCommonHub : AbpCommonHub
    {
        private readonly IRepository<ChatHistory, long> _chatHistoryRepository;

        private readonly ChatHistoryManager _chatHistoryManager;
        private readonly ChatMessageManager _chatMessageManager;
        private readonly IOnlineClientManager _onlineClientManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Abp.Web.SignalR.Hubs.AbpCommonHub" /> class.
        /// </summary>
        public PoliceCommonHub(IOnlineClientManager onlineClientManager, IRepository<ChatHistory, long> chatHistoryRepository, ChatHistoryManager chatHistoryManager, ChatMessageManager chatMessageManager) : base(onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;
            _chatHistoryRepository = chatHistoryRepository;
            _chatHistoryManager = chatHistoryManager;
            _chatMessageManager = chatMessageManager;
        }

        /// <summary>
        /// Called when the connection connects to this hub instance.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /></returns>
        public override async Task OnConnected()
        {
            await base.OnConnected();

            // 查询历史记录
            var chatMessages = await _chatHistoryManager.GetChatHistoryAsync(AbpSession.ToUserIdentifier());
            var chatMessageDto = chatMessages.MapTo<ChatMessageReceiveDto>();

            var clients = _onlineClientManager.GetAllByUserId(AbpSession.ToUserIdentifier());
            foreach (var onlineClient in clients)
            {
                Clients.Client(onlineClient.ConnectionId).getMessages(chatMessageDto);
            }
        }

        public async Task SendMessage(ChatMessageSendDto chatMessage)
        {
            var message = chatMessage.MapTo<ChatMessage>();

            message = await _chatMessageManager.AddMessageAsync(message);

            if (message.ChatSendType == ChatSendType.Group)
            {
            }
            else
            {
                var clients = _onlineClientManager.GetAllByUserId(new UserIdentifier(AbpSession.TenantId, message.ToUserId.Value));
                foreach (var onlineClient in clients)
                {
                    Clients.Client(onlineClient.ConnectionId).getMessage(message);
                }
            }
        }

        public async Task ReadMessages(List<long> messageIds)
        {
            await _chatHistoryManager.ReadMessagesAsync(AbpSession.ToUserIdentifier(),messageIds);
        }
    }
}