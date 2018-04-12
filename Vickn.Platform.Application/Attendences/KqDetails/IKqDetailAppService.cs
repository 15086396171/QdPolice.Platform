using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Vickn.Platform.Attendences.KqDetails.Dtos;

namespace Vickn.Platform.Attendences.KqDetails
{
    /// <summary>
    /// 考勤流水服务
    /// </summary>
  public  interface IKqDetailAppService:IApplicationService
  {
        /// <summary>
        /// 添加考勤流水记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResultDto> CreateAllDetailAsync(KqDetailDto input);
  }
}
