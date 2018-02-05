using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;

namespace Vickn.Platform.Chats
{
    public class ChatMessageManager : DomainService
    {
        private readonly IRepository<ChatMessage, long> _chatMessageRepository;
        private readonly IRepository<ChatGroup, long> _chatGroupRepository;
        private readonly IRepository<ChatHistory, long> _chatHistoryRepository;

        public ChatMessageManager(IRepository<ChatMessage, long> chatMessageRepository, IRepository<ChatHistory, long> chatHistoryRepository, IRepository<ChatGroup, long> chatGroupRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatHistoryRepository = chatHistoryRepository;
            _chatGroupRepository = chatGroupRepository;
        }

        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns></returns>
        public async Task<ChatMessage> AddMessageAsync(ChatMessage chatMessage)
        {
            chatMessage.Id = await _chatMessageRepository.InsertAndGetIdAsync(chatMessage);

            // 如果群组，遍历每个人插入记录
            if (chatMessage.ChatSendType == ChatSendType.Group)
            {
                var chatGroup = await _chatGroupRepository.GetAsync(chatMessage.ToGroupId.Value);

                foreach (var chatGroupUser in chatGroup.ChatGroupUsers)
                {
                    await _chatHistoryRepository.InsertAsync(new ChatHistory()
                    {
                        ChatMessageId = chatMessage.Id,
                        ToUserId = chatGroupUser.UserId
                    });
                }
            }
            else
            {
                await _chatHistoryRepository.InsertAsync(new ChatHistory()
                {
                    ChatMessageId = chatMessage.Id,
                    ToUserId = chatMessage.ToUserId.Value
                });
            }
            return chatMessage;
        }
    }
}