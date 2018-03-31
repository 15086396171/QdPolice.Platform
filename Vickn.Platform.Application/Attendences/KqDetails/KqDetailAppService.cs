using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendences.KqDetails.Dtos;
using Abp.Runtime.Session;

namespace Vickn.Platform.Attendences.KqDetails
{
    /// <summary>
    /// 考勤签到服务
    /// </summary>
    public class KqDetailService : PlatformAppServiceBase,IKqDetailAppService
    {
        private readonly IRepository<KqDetail> _attendanceDetailRepository;
        private readonly IRepository<KqAllDetail> _attendanceAllDetailRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attendanceDetailRepository"></param>
        /// <param name="attendanceAllDetailRepository"></param>
        public KqDetailService(IRepository<KqDetail> attendanceDetailRepository, IRepository<KqAllDetail> attendanceAllDetailRepository)
        {
            _attendanceDetailRepository = attendanceDetailRepository;
            _attendanceAllDetailRepository = attendanceAllDetailRepository;
        }


        /// <summary>
        ///  新增考勤签到记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> CreateKqDetailAsync(KqDetailForEdit input)
        {
            #region 通过post获取用户信息
            //int UserId = Convert.ToInt32(AbpSession.UserId);
            var user = await GetCurrentUserAsync();
            var NowUserName = user.Surname;
            #endregion

            #region 考勤流水，所有打卡记录都记录下来
            KqAllDetail kqalldetail = new KqAllDetail()
            {
                UserName = NowUserName,
                IsNFC = input.KqDetailEditDto.IsNFC,
                QDTime = DateTime.Now,
                QDPostion = input.KqDetailEditDto.QDPosition,

            };

            var kqalldetails = kqalldetail.MapTo<KqAllDetail>();
            kqalldetails = await _attendanceAllDetailRepository.InsertAsync(kqalldetails);
            #endregion

            #region 打卡业务逻辑处理

            #region 判断是否为第一次打卡



            DateTime StartNowDate = DateTime.Today;
            var AllKqList = await _attendanceDetailRepository.GetAllListAsync();
            var UserKqToDayList = AllKqList.Where(p => p.UserName == NowUserName && p.QDWorkTime != null && p.QDWorkTime > StartNowDate);
            if (UserKqToDayList == null)//该用户今天为第一次打卡
            {


            }
            else//该用户今天不是第一次打卡
            {

            }

            #endregion


            #region 记录当天考勤情况
            KqDetail kqdetail = new KqDetail()
            {
                UserName = NowUserName,
                IsNFC = input.KqDetailEditDto.IsNFC,
                QDClosingTime = DateTime.Now,
                QDWorkTime = DateTime.Now,
                Remark = "Ok",
                QDType = 1,
                KQMachineNo = input.KqDetailEditDto.QDPosition,

            };
            var kqdetails = kqdetail.MapTo<KqDetail>();
            kqdetails = await _attendanceDetailRepository.InsertAsync(kqdetails);
            #endregion


            #endregion






            //var entity = input.AttendancesEditDto.MapTo<KqDetail>();
            //entity = await _attendanceDetailRepository.InsertAsync(entity);

            return new ResultDto()
            {
                Success = true

            };

        }
    }
}
