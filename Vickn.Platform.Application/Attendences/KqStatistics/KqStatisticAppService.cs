using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Organizations;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendances.KqShifts;
using Vickn.Platform.Attendences.KqStatistics.Dtos;
using Vickn.Platform.Users;

namespace Vickn.Platform.Attendences.KqStatistics
{
    public class KqStatisticAppService : IKqStatisticAppService
    {
        private readonly IRepository<KqDetail> _KqDetailRepository;
        private readonly IRepository<User, long> _Usersrepository;
 
        private readonly IRepository<KqShift, long> _KqShiftUnitRepository;
        private readonly IRepository<KqShiftUser, long> _KqShiftUserRepository;
        private IKqStatisticAppService _kqStatisticAppServiceImplementation;

        public KqStatisticAppService(IRepository<KqDetail> KqDetailRepository, IRepository<User, long> Usersrepository, IRepository<KqShift, long> KqShiftUnitRepository,  IRepository<KqShiftUser, long> KqShiftUserRepository)
        {
            _KqDetailRepository = KqDetailRepository;
            _Usersrepository = Usersrepository;
            _KqShiftUnitRepository = KqShiftUnitRepository;
            _KqShiftUserRepository = KqShiftUserRepository;
          
        }





        /// <summary>
        /// app获取考勤Dto(一个月)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<KqAppResultYMdDto>> GetAppKqStatisticAsync(GetKqStatisticAppDto input)
        {
            var StartTime = input.Date + "/01 00:00:00";

            DateTime StartTimes = Convert.ToDateTime(StartTime);

            DateTime EndTimes = StartTimes.AddMonths(1).AddHours(-1);

            var entity = await _KqDetailRepository.GetAllListAsync(p =>
                p.UserName.Contains(input.UserName) && p.QDWorkTime > StartTimes && p.QDWorkTime < EndTimes);

            List<KqAppResultYMdDto> kqList = new List<KqAppResultYMdDto>();

            for (int i = 0; i < entity.Count(); i++)
            {
                KqAppResultYMdDto list = new KqAppResultYMdDto();
                list.DateYMD = entity[i].QDWorkTime.ToString("yyyy.MM.dd");
                list.DateWork = entity[i].QDWorkTime.ToString("HH:mm:ss");
                list.DateColsing = entity[i].QDClosingTime.ToString("HH:mm:ss");
                if (entity[i].QDType == 0)
                {
                    list.QDType = "正常";
                }
                if (entity[i].QDType == 1)
                {
                    list.QDType = "迟到";
                }
                if (entity[i].QDType == 2)
                {
                    list.QDType = "早退";
                }
                if (entity[i].QDType == 3)
                {
                    list.QDType = "缺勤";
                }


                kqList.Add(list);

            }

            return kqList;
        }

        /// <summary>
        /// app获取考勤Dto（一天）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<KqStatisticYMdDto>> GetAppKqRecordAsync(GetKqStatisticAppDto input)
        {
            var StartTime = input.Date + " 00:00:00";

            DateTime StartTimes = Convert.ToDateTime(StartTime);

            DateTime EndTimes = StartTimes.AddDays(1).AddSeconds(-1);

            var entity = await _KqDetailRepository.GetAllListAsync(p =>
                p.UserName.Contains(input.UserName) && p.QDWorkTime > StartTimes && p.QDWorkTime < EndTimes);
            List<KqStatisticYMdDto> kqList = new List<KqStatisticYMdDto>();
            var listcount = entity.Count();
            if (listcount != 0)
            {

                KqStatisticYMdDto list = new KqStatisticYMdDto();
                list.DateWork = entity[0].QDWorkTime.ToString("HH:mm:ss");
                list.DateColsing = entity[0].QDClosingTime.ToString("HH:mm:ss");
                kqList.Add(list);

            }
            else
            {

                KqStatisticYMdDto list = new KqStatisticYMdDto();
                list.DateWork = "--:--:--";
                list.DateColsing = "--:--:--";

                kqList.Add(list);
            }


            return kqList;
        }


        /// <summary>
        /// 根据条件查询考勤Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<KqStatisicListDto>> GetKqStatisticAsync(GetKqStatisticInputDto input)
        {
            //判断时间是否为null
            if (input.EndTime == null || input.StartTime == null)
            {
                input.StartTime = input.EndTime = null;
            }
            else
            {
                input.EndTime = input.EndTime.Value.AddDays(1);

            }

            #region 查询条件判断

            List<KqDetail> entity = new List<KqDetail>();
            if (!string.IsNullOrEmpty(input.UserName) && input.StartTime != null && input.EndTime != null)
            {
                entity = _KqDetailRepository.GetAllList(p =>
                    p.QDWorkTime <= input.EndTime && p.QDWorkTime > input.StartTime && p.UserName.Contains(input.UserName));
            }
            else if (!string.IsNullOrEmpty(input.UserName) || input.StartTime != null && input.EndTime != null)
            {
                if (input.StartTime != null && input.EndTime != null)
                {

                    entity = _KqDetailRepository.GetAllList(p => p.QDWorkTime <= input.EndTime && p.QDWorkTime > input.StartTime);
                }
                else
                {
                    entity = _KqDetailRepository.GetAllList(p => p.UserName.Contains(input.UserName));
                }


            }
            else
            {
                entity = _KqDetailRepository.GetAllList();
            }

            entity = entity.OrderBy(p => p.UserName).ToList();

            var entityUserlist = (from d in entity
                                  group d by d.UserName).ToList();
            #endregion



            #region 统计整理考勤数据

            List<KqStatisicListDto> KqStatisticList = new List<KqStatisicListDto>();
            for (int i = 0; i < entityUserlist.Count(); i++)
            {
                KqStatisicListDto list = new KqStatisicListDto();

                list.UserName = entityUserlist[i].Key;
                var userName = entityUserlist[i].Key;

                long UserId = _Usersrepository.FirstOrDefault(p => p.UserName == userName).Id;
                long KqShiftId = _KqShiftUserRepository.FirstOrDefault(p => p.UserId == UserId).KqShiftId;
                list.KqShiftName = _KqShiftUnitRepository.FirstOrDefault(p => p.Id == KqShiftId).ShiftName;
                list.NormalDay = entity.Count(p => p.QDType == 0 && p.UserName == userName);
                list.LateDay = entity.Count(p => p.QDType == 1 && p.UserName == userName);
                list.LeaveEarlyDay = entity.Count(p => p.QDType == 2 && p.UserName == userName);
                list.AbsenteeismDay = entity.Count(p => p.QDType == 3 && p.UserName == userName);
                list.AbnormalDay = entity.Count(p => p.QDType == 5 && p.UserName == userName);
                KqStatisticList.Add(list);


            }


            #endregion



            ////TODO:根据传入的参数添加过滤条件
            int kqStatisticCount = KqStatisticList.Count();
            var kqStatisticL = KqStatisticList.OrderBy(p => p.UserName).ToList();
            var KqStatistics = kqStatisticL.MapTo<List<KqStatisicListDto>>();
            return new PagedResultDto<KqStatisicListDto>(kqStatisticCount, kqStatisticL);


        }

        /// <summary>
        /// 根据用户姓名条件查该用户考勤明细Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<KqDetailStatisticListDto>> GetKqDetailStatisticAsync(GetKqStatisticInputDto input)
        {
            //判断时间是否为null
            if (input.EndTime == null || input.StartTime == null)
            {
                input.StartTime = input.EndTime = null;
            }
            else
            {
                input.EndTime.Value.AddDays(1);
            }

            #region 查询条件判断

            List<KqDetail> entity = new List<KqDetail>();
            if (!string.IsNullOrEmpty(input.UserName) && input.StartTime != null && input.EndTime != null)
            {
                entity = _KqDetailRepository.GetAllList(p =>
                    p.QDWorkTime <= input.EndTime && p.QDWorkTime > input.StartTime && p.UserName.Contains(input.UserName));
            }
            else if (!string.IsNullOrEmpty(input.UserName) || input.StartTime != null && input.EndTime != null)
            {
                if (input.StartTime != null && input.EndTime != null)
                {

                    entity = _KqDetailRepository.GetAllList(p => p.QDWorkTime <= input.EndTime && p.QDWorkTime > input.StartTime);
                }
                else
                {
                    entity = _KqDetailRepository.GetAllList(p => p.UserName.Contains(input.UserName));
                }


            }
            else
            {
                entity = _KqDetailRepository.GetAllList();
            }

            #endregion







            List<KqDetailStatisticListDto> kqList = new List<KqDetailStatisticListDto>();

            for (int i = 0; i < entity.Count(); i++)
            {
                KqDetailStatisticListDto list = new KqDetailStatisticListDto();
                list.UserName = entity[i].UserName;
                list.DateYMD = entity[i].QDWorkTime.ToString("yyyy-MM-dd");
                list.DateWork = entity[i].QDWorkTime.ToString("HH:mm:ss");
                list.QDPostionWork = entity[i].QDPostionWork;
                list.OutgoingCauseWork = entity[i].OutgoingCauseWork;
                list.DateColsing = entity[i].QDClosingTime.ToString("HH:mm:ss");
                list.QDPostionClosing = entity[i].QDPostionClosing;
                list.OutgoingCauseClosing = entity[i].OutgoingCauseClosing;
                if (entity[i].QDType == 0)
                {
                    list.QDType = "正常";
                }
                if (entity[i].QDType == 1)
                {
                    list.QDType = "迟到";
                }
                if (entity[i].QDType == 2)
                {
                    list.QDType = "早退";
                }
                if (entity[i].QDType == 3)
                {
                    list.QDType = "缺勤";
                }
                if (entity[i].QDType == 5)
                {
                    list.QDType = "异常";
                }

                kqList.Add(list);

            }






            ////TODO:根据传入的参数添加过滤条件
            int kqStatisticCount = kqList.Count();
            var kqStatisticL = kqList.OrderBy(p => p.UserName).ToList();
            var KqStatistics = kqStatisticL.MapTo<List<KqDetailStatisticListDto>>();
            return new PagedResultDto<KqDetailStatisticListDto>(kqStatisticCount, kqStatisticL);
        }
    }
}
