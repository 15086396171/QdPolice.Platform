using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Vickn.Platform.Users;

namespace Vickn.Platform.Announcements
{
    /// <summary>
    /// 通知接收用户
    /// </summary>
    public class AnnouncementUser:Entity<long>
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long AnnouncementId { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }

    }
}