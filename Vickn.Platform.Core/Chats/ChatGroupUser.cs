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

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }
    }
}