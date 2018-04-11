using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqMachines.Dtos
{
    /// <summary>
    /// 考勤机管理编辑Dto
    /// </summary>
    public class KqMachineEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }

        /// <summary>
        /// 考勤机编号
        /// </summary>
        [DisplayName("考勤机编号")]
        public int KQMachineNo { get; set; }
        /// <summary>
        /// 考勤机地理位置
        /// </summary>
        [DisplayName("考勤机地理位置")]
        [Required]
        public string KQMachinePosition { get; set; }
    }
}
