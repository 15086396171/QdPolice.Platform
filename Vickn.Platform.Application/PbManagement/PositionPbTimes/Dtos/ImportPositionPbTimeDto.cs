using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.PbManagement.PositionPbMaps.Dtos;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 排班岗位时间表Dto
    /// </summary>
    [AutoMap(typeof(PositionPbTime))]
    public class ImportPositionPbTimeDto:Entity
    {
        [Description("岗位排班Id")]
        public int PositionPbId { get; set; }

        public bool IsDuty { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        [Description("上班时间")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        [Description("下班时间")]
        public DateTime EndTime { get; set; }

        public long UserId { get; set; }

        public string RealName { get; set; }

        public ICollection<PositionPbMapDto> PositionPbMaps { get; set; }
    }
}
