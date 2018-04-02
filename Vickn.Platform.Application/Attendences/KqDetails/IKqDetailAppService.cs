using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendences.KqDetails.Dtos;

namespace Vickn.Platform.Attendences.KqDetails
{
    /// <summary>
    /// 考勤签到服务接口
    /// </summary>
    interface IKqDetailAppService: IApplicationService
    {
        /// <summary>
        ///用户打卡向数据库添加考勤打卡记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResultDto> CreateKqDetailAsync(KqDetailForEdit input);
    }
}
