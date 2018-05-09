using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
    /// <summary>
    /// 单个岗位下排班时间管理Dto
    /// </summary>
    [AutoMap(typeof(PositionPb))]
    public class PositionPbListDto : EntityDto<int>
    {

        /// <summary>
        /// 单个岗位排班标题Id
        /// </summary>
        [DisplayName("单个岗位排班标题Id")]
        public int PbPositionId { get; set; }

        /// <summary>
        /// 值班日期
        /// </summary>
        [DisplayName("值班日期")]
        public DateTime DutyDate { get; set; }

        /// <summary>
        /// 岗位值班时间信息
        /// </summary>
        public virtual List<PositionTimeListDto> PositionPbTimes { get; set; }

    }
}
