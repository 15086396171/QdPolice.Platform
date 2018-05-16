using Abp.Domain.Entities;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
    /// <summary>
    /// 岗位值班时间信息
    /// </summary>
    public class PositionTimeListDto
    {
        /// <summary>
        /// 上班时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 岗位排班Id
        /// </summary>
        public long PositionPbId { get; set; }

    }
}