using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Zero.Users.Dtos
{
   public class UserLeadersListDto
    {
       /// <summary>
       /// 用户Id
       /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户岗位
        /// </summary>
        public string UserPosition { get; set; }

        /// <summary>
        /// 用户名和岗位
        /// </summary>
        public string UserNameAndPosition { get; set; }

    }
}
