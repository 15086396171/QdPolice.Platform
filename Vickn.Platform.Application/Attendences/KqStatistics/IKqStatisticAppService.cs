using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendences.KqStatistics.Dtos;

namespace Vickn.Platform.Attendences.KqStatistics
{
   public interface IKqStatisticAppService: IApplicationService
   {
        /// <summary>
        ///根据时间、用户名获取考勤统计数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<KqStatisticEditDto>> GetKqStatisticAsync(GetKqStatisticInputDto input);

        /// <summary>
        /// app获取考勤Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task< List<KqAppResultYMdDto>> GetAppKqStatisticAsync(GetKqStatisticAppDto input);

       
   }
}
