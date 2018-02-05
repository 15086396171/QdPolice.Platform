using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists
{
    /// <summary>
    /// 应用白名单
    /// </summary>
    public class AppWhiteList:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
    }
}