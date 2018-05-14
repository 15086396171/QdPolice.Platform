using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 用户当天上下班时间信息Dto
    /// </summary>
    public class PositionPbUserTimeListDto
    {
        /// <summary>
        /// 上下班信息Id
        /// </summary>
        public long PositionPbTimeId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 排班岗位
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 工作时间段
        /// </summary>
        public string WorkTime {get; set; }

    }
}
