using Abp.Domain.Entities.Auditing;
using Vickn.Platform.Users;

namespace Vickn.Platform.HandheldTerminals.Devices
{
    /// <summary>
    /// 设备
    /// </summary>
    public class Device:FullAuditedEntity<long>
    {
        public virtual User User { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }
    }
}