using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
    ///考勤统计导出查询参数
    public class GetExportKqStatisticDto
    {
        //DOTO:在这里增加查询参数

        /// <summary>
        /// 模糊查询用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? EndTime { get; set; }


        /// <summary>
        /// 是否异常
        /// </summary>
        public string IsUnusual { get; set; }


        /// <summary>
        /// 考勤班次名称
        /// </summary>
        public string KqShiftName { get; set; }

    }
}
