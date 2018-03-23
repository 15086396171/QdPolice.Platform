using Abp.AutoMapper;
using Abp.Domain.Repositories;
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
    /// 考勤签到服务
    /// </summary>
    public class AttendanceAppService : PlatformAppServiceBase, IAttendanceAppService
    {
        private readonly IRepository<Detail> _attendanceDetailRepository;

        public  AttendanceAppService(IRepository<Detail> attendanceDetailRepository)
        {
            _attendanceDetailRepository = attendanceDetailRepository;
        }


        public async Task<AttendancesEditDto> CreateAsync(AttendancesEditDto input)
        {
            var entity = input.AttendanceDto.MapTo<Detail>();
            entity = await _attendanceDetailRepository.InsertAsync(entity);
            return new AttendancesEditDto { AttendanceDto = entity.MapTo<AttendanceDto>() };
        }

        
    }
}
