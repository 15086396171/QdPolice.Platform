using Abp.Domain.Entities.Auditing;
using Vickn.Platform.HandheldTerminals.Devices;

namespace Vickn.Platform.HandheldTerminals
{
    /// <summary>
    /// 取证记录
    /// </summary>
    public class ForensicsRecord:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 模式
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public ForensicsRecordType ForensicsRecordType { get; set; }

        public virtual Device Device { get; set; }

        public long DeviceId { get; set; }
    }

    public enum ForensicsRecordType
    {
        Audio,
        Video,
        Picture,
    }
}