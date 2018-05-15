using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.PbManagement.ChangeWorks.Dtos
{
   public class AppChangeWorkEditDto
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 发起人岗位
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 发起人值班时间
        /// </summary>

        public List<PositionPbTimeListDto> TimeStr { get; set; }


        /// <summary>
        /// 被换班人值班时间
        /// </summary>
        public List<PositionPbTimeListDto> BeTimeStrs { get; set; }

        ///// <summary>
        ///// 被换班人-第二接口
        ///// </summary>
        //public string BeUserName { get; set; }


        /// <summary>
        /// 被换班人岗位
        /// </summary>
        public string BePositionName { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>

        public List<UserLeadersListDto> Leaders { get; set; }

       
    }
}
