using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.Announcements
{
    /// <summary>
    /// 通知公告
    /// </summary>
    public class Announcement:FullAuditedEntity<long>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}