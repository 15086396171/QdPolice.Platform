using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using JetBrains.Annotations;

namespace Vickn.Platform.Chats
{
    public class ChatGroupManager : DomainService
    {
        private readonly IRepository<ChatGroup, long> _chatGroupRepository;

        public ChatGroupManager(IRepository<ChatGroup, long> chatGroupRepository)
        {
            _chatGroupRepository = chatGroupRepository;
        }

        public async Task<ChatGroup> CreateGroupAsync(string name)
        {
            if (_chatGroupRepository.FirstOrDefault(p => p.Name == name) != null)
                throw new UserFriendlyException("房间名已存在");

            var chatGroup = await _chatGroupRepository.InsertAsync(new ChatGroup()
            {
                Name = name
            });

            return chatGroup;
        }

        public async Task<List<ChatGroup>> GetGroupsAsync([NotNull] UserIdentifier userIdentifier)
        {
            var chatGroups = await _chatGroupRepository.GetAllListAsync(p => p.ChatGroupUsers.Select(q => q.UserId).Contains(userIdentifier.UserId));
            return chatGroups;
        }
    }
}