using Abp.Domain.Entities;
using Vickn.Platform.Users;

namespace Vickn.Platform.Schedules.PlatoonGroups
{
    public class GroupMember : Entity<long>
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long PlatoonGroupId { get; set; }

    }
}