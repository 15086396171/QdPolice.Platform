using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Attendances;
using Vickn.Platform.Attendences.Dtos;

namespace Vickn.Platform.Attendences
{
    /// <summary>
    /// 考勤签到服务接口
    /// </summary>
   public interface IAttendanceAppService: IApplicationService
    {
        #region 考勤签到管理
        /// <summary>
        ///  新增考勤黔到记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AttendanceResultDto> CreateKqDetailAsync(AttendanceForEdit input);

        #endregion
    }
}
