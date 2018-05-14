using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.ChangeWorkNotifis
{
   public class ChangeWorkNotifi: FullAuditedEntity<long>
    {

        public int UserId { get; set; }

        public int ChangeWorkId { get; set; }

        /// <summary>
        /// 换班成功、失败
        /// </summary>
        public bool Status { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// 网页已读
        /// </summary>
        public bool ReadInWeb { get; set; }

        /// <summary>
        /// app已读
        /// </summary>
        public bool ReadInApp { get; set; }
    }
}
