using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Vickn.Platform.Attendences.KqStatistics.Dtos;

namespace Vickn.Platform.Attendences.KqStatistics
{
    public interface IKqStatisticAppService : IApplicationService
    {


        /// <summary>
        /// app获取考勤Dto（一个月）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task<List<KqAppResultYMdDto>> GetAppKqStatisticAsync(GetKqStatisticAppDto input);

        /// <summary>
        /// app获取考勤Dto（一天）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<KqStatisticYMdDto>> GetAppKqRecordAsync(GetKqStatisticAppDto input);

        /// <summary>
        /// 根据条件查考勤统计Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<KqStatisicListDto>> GetKqStatisticAsync(GetKqStatisticInputDto input);


        /// <summary>
        /// 根据用户姓名条件查该用户考勤明细Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<KqDetailStatisticListDto>> GetKqDetailStatisticAsync(GetKqStatisticInputDto input);
    }
}