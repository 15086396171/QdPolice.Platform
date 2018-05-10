using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// app调用后台获取排班信息接口参数
    /// </summary>
   public class AppGetPositionPbDto
    {
        /// <summary>
        ///排班日期（年月日）
        /// </summary>
        public DateTime PbDate{ get; set; }
    }
}
