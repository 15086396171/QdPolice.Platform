using Abp.Domain.Entities.Auditing;
using Vickn.Platform.Users;

namespace Vickn.Platform.PrivatePhoneWhites
{
    /// <summary>
    /// 个人白名单
    /// </summary>
    public class PrivatePhoneWhite:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string  PhoneNumber { get; set; }

        /// <summary>
        /// 所属人Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 所属人
        /// </summary>
        public virtual User User { get; set; }
    }
}