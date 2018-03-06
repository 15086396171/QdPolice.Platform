using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.UI;
using JetBrains.Annotations;

namespace Vickn.Platform.Chats
{
    public class ChatGroupManager : DomainService
    {
        private readonly IRepository<ChatGroup, long> _chatGroupRepository;
        private readonly IRepository<ChatGroupUser, long> _chatUserRepository;

        public ChatGroupManager(IRepository<ChatGroup, long> chatGroupRepository, IRepository<ChatGroupUser, long> chatUserRepository)
        {
            _chatGroupRepository = chatGroupRepository;
            _chatUserRepository = chatUserRepository;
        }

        /// <summary>
        /// 创建群组
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ChatGroup> CreateGroupAsync(UserIdentifier userIdentifier, string name)
        {
            if (_chatGroupRepository.FirstOrDefault(p => p.Name == name) != null)
                throw new UserFriendlyException("房间名已存在，创建群失败");

            var chatGroup = new ChatGroup()
            {
                Name = name,
                ChatGroupUsers = new List<ChatGroupUser>()
            };
            chatGroup.ChatGroupUsers.Add(new ChatGroupUser()
            {
                UserId = userIdentifier.UserId,
                ChatGroupUserType = ChatGroupUserType.Owner
            });

            await _chatGroupRepository.InsertAsync(chatGroup);

            return chatGroup;
        }

        public async Task<ChatGroup> InviteToGroupAsync(long groupId, List<long> userIds)
        {
            var chatGroup = await _chatGroupRepository.GetAsync(groupId);
            foreach (var userId in userIds)
            {
                if (_chatUserRepository.FirstOrDefault(p => p.ChatGroupId == chatGroup.Id && p.UserId == userId) == null)
                {
                    await _chatUserRepository.InsertAsync(new ChatGroupUser()
                    {
                        UserId = userId,
                        ChatGroupId = chatGroup.Id
                    });
                }
            }
            return chatGroup;
        }

        /// <summary>
        /// 根据组名获取该组用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChatGroupUser>> GetChatGroupUsers(long id)
        {
            var query = from chatGroup in _chatGroupRepository.GetAll()
                        join chatGroupUser in _chatUserRepository.GetAll() on chatGroup.Id equals chatGroupUser.ChatGroupId
                        where chatGroup.Id == id
                        select chatGroupUser;
            return await query.ToListAsync();
        }

        /// <summary>
        /// 获取群组列表
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <returns></returns>
        public async Task<List<ChatGroup>> GetGroupsAsync([NotNull] UserIdentifier userIdentifier)
        {
            var chatGroups = await _chatGroupRepository.GetAllListAsync(p => p.ChatGroupUsers.Select(q => q.UserId).Contains(userIdentifier.UserId));
            return chatGroups;
        }

        public async Task<ChatGroup> GetGroupByIdAsync(long id)
        {
            return await _chatGroupRepository.GetAsync(id);
        }
    }
}