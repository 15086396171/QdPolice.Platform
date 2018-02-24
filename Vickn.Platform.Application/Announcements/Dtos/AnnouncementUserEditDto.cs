using Abp.AutoMapper;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Announcements.Dtos
{
    [AutoMap(typeof(AnnouncementUser))]
    public class AnnouncementUserEditDto
    {
        public long? Id { get; set; }

        public long UserId { get; set; }

        public UserListDto User { get; set; }

        public long? AnnouncementId { get; set; }

    }
}