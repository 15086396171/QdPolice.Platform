using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using JetBrains.Annotations;

namespace Vickn.Platform.Chats
{
    public class ChatHistoryManager : DomainService
    {
        private readonly IRepository<ChatHistory, long> _chatHistoryRepository;
        private readonly IRepository<ChatMessage, long> _chatMessageRepository;

        public ChatHistoryManager(IRepository<ChatHistory, long> chatHistoryRepository, IRepository<ChatMessage, long> chatMessageRepository)
        {
            _chatHistoryRepository = chatHistoryRepository;
            _chatMessageRepository = chatMessageRepository;
        }

        public async Task<List<ChatMessage>> GetChatHistoryAsync([NotNull]UserIdentifier userIdentifier)
        {
            var chatHistories = await _chatHistoryRepository.GetAllListAsync(p => p.ToUserId == userIdentifier.UserId);
            var chatMessages = chatHistories.Select(p => p.ChatMessage).ToList();
            return chatMessages;
        }

        public async Task ReadMessagesAsync([NotNull]UserIdentifier userIdentifier, List<long> messageIds)
        {
            var chatHistories = await _chatHistoryRepository.GetAllListAsync(p => p.ToUserId == userIdentifier.UserId && messageIds.Contains(p.ChatMessageId));

            foreach (var chatHistory in chatHistories)
            {
                if (_chatHistoryRepository.FirstOrDefault(
                        p => p.ToUserId != userIdentifier.UserId && p.ChatMessageId == chatHistory.Id) == null)
                {
                    await _chatMessageRepository.DeleteAsync(chatHistory.ChatMessageId);
                }
                await _chatHistoryRepository.DeleteAsync(chatHistory.Id);
            }
        }
    }
}