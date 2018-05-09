using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
    /// <summary>
    /// 岗位排班列表信息Dto
    /// </summary>
  public  class PositionPbListForEdit
    {
        public virtual List<PositionPbListDto> PositionPbListDtos { get; set; }


        /// <summary>
        /// 本月天数
        /// </summary>
        public string Count { get; set; }


        /// <summary>
        /// 当前年月
        /// </summary>
        public string NowDateMonth { get; set; }
    }
}
