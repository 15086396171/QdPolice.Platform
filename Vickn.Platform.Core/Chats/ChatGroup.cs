using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using Vickn.Platform.Users;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 群组
    /// </summary>
    public class ChatGroup:FullAuditedEntity<long>
    {
        /// <summary>
        /// 群组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户列表
        /// </summary>
        public virtual ICollection<ChatGroupUser> ChatGroupUsers { get; set; }
    }
}