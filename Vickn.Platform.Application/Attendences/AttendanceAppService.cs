using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.PlatfForm.Utils.Extensions;
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
        private readonly IRepository<KqAllDetail> _attendanceAllDetailRepository;

        public  AttendanceAppService(IRepository<KqDetail> attendanceDetailRepository,IRepository<KqAllDetail> attendanceAllDetailRepository)
        {
            _attendanceDetailRepository = attendanceDetailRepository;
            _attendanceAllDetailRepository = attendanceAllDetailRepository;
        }


        /// <summary>
        ///  新增考勤签到记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AttendanceResultDto> CreateKqDetailAsync(AttendanceForEdit input)
        {
            #region 打卡业务逻辑处理

            int UserId =Convert.ToInt32(AbpSession.UserId);
            //string UserName = GetCurrentUserAsync().Result.UserName;

            #endregion

            KqAllDetail kqalldetail = new KqAllDetail();
            //{
            //    IsNFC = input.AttendancesEditDto.IsNFC,
            //    UserName = Convert.ToString(UserManager.FindByIdAsync(UserId).Result.Name),
            //    QDTime = DateTime.Now,
            //};
            kqalldetail.UserName = GetCurrentUserAsync().Result.UserName;


            //var entity = input.AttendancesEditDto.MapTo<KqDetail>();
            //entity = await _attendanceDetailRepository.InsertAsync(entity);

            //var Allentity = input.AttendancesEditDto.MapTo<KqAllDetail>();
            //Allentity = await _attendanceAllDetailRepository.InsertAsync(Allentity);

            return new AttendanceResultDto()
            {
                Result = "OK",
              
            };

        }
    }
}
