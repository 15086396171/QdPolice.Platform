using Abp.Domain.Entities;
using Vickn.Platform.Users;

namespace Vickn.Platform.Chats
{
    public class ChatGroupUser:Entity<long>
    {
        /// <summary>
        /// 群组Id
        /// </summary>
        public long ChatGroupId { get; set; }

        public ChatGroupUserType ChatGroupUserType { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }
    }

    public enum ChatGroupUserType
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        Default,

        /// <summary>
        /// 管理员
        /// </summary>
        Admin,

        /// <summary>
        /// 创建者
        /// </summary>
        Owner,
    }
}