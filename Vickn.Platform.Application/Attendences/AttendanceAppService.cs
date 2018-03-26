using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Attendances;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendences.Dtos;

namespace Vickn.Platform.Attendences
{

    /// <summary>
    /// 考勤签到服务
    /// </summary>
    public class AttendanceAppService : PlatformAppServiceBase, IAttendanceAppService
    {
        private readonly IRepository<KqDetail> _attendanceDetailRepository;

        public  AttendanceAppService(IRepository<KqDetail> attendanceDetailRepository)
        {
            _attendanceDetailRepository = attendanceDetailRepository;
        }


        /// <summary>
        ///  新增考勤黔到记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AttendanceForEdit> CreateKqDetailAsync(AttendanceForEdit input)
        {
            var entity = input.AttendancesEditDto.MapTo<KqDetail>();
            entity = await _attendanceDetailRepository.InsertAsync(entity);
            return new AttendanceForEdit { AttendancesEditDto = entity.MapTo<AttendancesEditDto>() };
        }
    }
}
