using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
   public class GetKqStatisticAppDto
    {
        public string UserName { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string Date { get; set; }
        
    }
}
