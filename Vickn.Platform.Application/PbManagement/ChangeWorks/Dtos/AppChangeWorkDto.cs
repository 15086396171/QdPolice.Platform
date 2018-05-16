using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.ChangeWorks.Dtos
{
  public  class AppChangeWorkDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 发起人值班时间
        /// </summary>

        public string TimeStr { get; set; }

        /// <summary>
        /// 发起人岗位
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 换班原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 被换班人
        /// </summary>
        public string BeUserName { get; set; }

        /// <summary>
        /// 被换班人值班时间
        /// </summary>
        public string BeTimeStrs { get; set; }


        /// <summary>
        /// 被换班人岗位
        /// </summary>
        public string BePositionName { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>

        public string Leaders { get; set; }
    }
}
