using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
   public class GetPositonPbListInput
    {
        /// <summary>
        /// 单个岗位排班标题Id
        /// </summary>
        [DisplayName("单个岗位排班标题Id")]
        public int PbPositionId { get; set; }
    }
}
