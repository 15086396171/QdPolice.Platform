using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.FileRecords
{
    /// <summary>
    /// 文件记录
    /// </summary>
    public class FileRecord:FullAuditedEntity
    {
        /// <summary>
        /// 标记在其他文件中的文件id
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件本地保存地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
    }
}