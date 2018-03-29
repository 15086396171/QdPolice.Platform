using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.KqMachines
{
   /// <summary>
   /// 考勤机信息管理
   /// </summary>
    public class KqMachine :FullAuditedEntity<long>
    {
        /// <summary>
        /// 考勤机编号
        /// </summary>
        public int KQMachineNo { get; set; }
        /// <summary>
        /// 考勤机地理位置
        /// </summary>
        public string KQMachinePosition { get; set; }


    }
}
