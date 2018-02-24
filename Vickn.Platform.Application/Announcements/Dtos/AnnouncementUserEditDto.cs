using Abp.AutoMapper;

namespace Vickn.Platform.Announcements.Dtos
{
    [AutoMap(typeof(AnnouncementUserEditDto))]
    public class AnnouncementUserEditDto
    {
        public long? Id { get; set; }

        public long UserId { get; set; }

    }
}