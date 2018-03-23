using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances
{
    public class AtUserTime
    {
        /// <summary>
        /// 进行修改操作的用户Id
        /// </summary>
        public int AtUpdateUserId { get; set; }

        /// <summary>
        /// 进行修改操作的用户名
        /// </summary>
        public string AtUpdateUser { get; set; }

        /// <summary>
        /// 进行修改操作的时间
        /// </summary>
        public DateTime AtUpdateDate { get; set; }
    }
}
