using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendances.KqMachines;
using Vickn.Platform.Attendances.KqShifts;
using Vickn.Platform.Attendences.KqDetails.Dtos;

namespace Vickn.Platform.Attendences.KqDetails
{
    public class KqDetailAppService : PlatformAppServiceBase, IKqDetailAppService
    {
        private readonly IRepository<KqAllDetail> _KqAllDeatilRepository;
        private readonly IRepository<KqDetail> _KqDetailRepository;
        private readonly IRepository<KqShift, long> _KqShiftRepository;
        private readonly IRepository<KqShiftUser, long> _KqShiftUserRepository;
        private readonly IRepository<KqMachine, long> _KqMachineRepository;

        /// <summary>
        /// 初始化考勤班次服务实例
        /// </summary>
        public KqDetailAppService(IRepository<KqAllDetail> KqAllDeatilRepository, IRepository<KqDetail> KqDetailRepository, IRepository<KqShift, long> KqShiftRepository, IRepository<KqShiftUser, long> KqShiftUserRepository, IRepository<KqMachine, long> KqMachineRepository)
        {
            _KqAllDeatilRepository = KqAllDeatilRepository;
            _KqDetailRepository = KqDetailRepository;
            _KqShiftRepository = KqShiftRepository;
            _KqShiftUserRepository = KqShiftUserRepository;
            _KqMachineRepository = KqMachineRepository;
        }

        /// <summary>
        /// 添加考勤流水记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> CreateAllDetailAsync(KqDetailDto input)
        {
            //获得用户信息
            var user = await GetCurrentUserAsync();
            string NowUserName = user.Surname;
            //当前打卡时间
            DateTime NowTime = DateTime.Now;

            #region 考勤流水存入数据库
            KqDetailEditDto KqAllDetaillist = new KqDetailEditDto();
            KqAllDetaillist.UserName = NowUserName;
            KqAllDetaillist.IsNFC = input.isNFC;
            KqAllDetaillist.QDPostion = "";
            KqAllDetaillist.QDTime = NowTime;
            var entity = KqAllDetaillist.MapTo<KqAllDetail>();
            await _KqAllDeatilRepository.InsertAsync(entity);
            #endregion

            #region 查看此用户是否有绑定的考勤班次
            var KqShiftUser = await _KqShiftUserRepository.FirstOrDefaultAsync(p => p.UserId == user.Id);
            if (KqShiftUser == null)
            {
                var LogContent = NowUserName + "用户,目前还没有绑定考勤班次.";
                Logger.Info(LogContent);


            }

            else
            {
                var IsKqShift = await _KqShiftRepository.FirstOrDefaultAsync(p => p.Id == KqShiftUser.KqShiftId);
                if (IsKqShift == null)
                {
                    var LogContent2 = NowUserName + "用户,目前还没有绑定考勤班次.";
                    Logger.Info(LogContent2);
                }
                else
                {
                    KqDetailEditDtos KqDetaillist = new KqDetailEditDtos();
                    KqDetaillist.UserName = NowUserName;
                    KqDetaillist.IsNFC = input.isNFC;
                    KqDetaillist.QDPostion = "";
                    KqDetaillist.QDTime = NowTime;
                    KqDetaillist.KqShiftId = KqShiftUser.KqShiftId;

                    //新增或修改此用户当天的考勤记录
                    await CreateOrUpdateAsync(KqDetaillist);
                }


            }
            #endregion



            return new ResultDto()
            {
                IsOk = true
            };
        }

        /// <summary>
        ///  新增或修改考勤记录信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(KqDetailEditDtos input)
        {
            //判断此用户是否为第一次打卡
            DateTime Todaytime = DateTime.Today;

            var entity = await _KqDetailRepository.FirstOrDefaultAsync(p => p.UserName == input.UserName && Todaytime < p.QDWorkTime);
            if (entity == null)
            {

                await CreateAsync(input);
            }
            else
            {
                await UpdateAsync(entity.Id, input);
            }
        }

        /// <summary>
        /// 新增考勤记录(第一次打卡)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(KqDetailEditDtos input)
        {


            //不同打卡方式(IsNFC(微信扫码：0，警务通NFC：1，门禁：2))
            if (input.IsNFC == 0)
            {
                //根据用户使用微信打卡离设定打卡二维码之间的距离是否超过50m，来判断打卡是否有效


            }

            else if (input.IsNFC == 1)
            {
                KqRecordEditDto kqrecord = new KqRecordEditDto();
                kqrecord.UserName = input.UserName;
                kqrecord.IsNFC = input.IsNFC;
                kqrecord.KQMachineNo = "";
                kqrecord.Remark = "";
                kqrecord.QDWorkTime = input.QDTime;
                kqrecord.QDClosingTime = null;
                kqrecord.QDType = null;

                var kqrecordDto = kqrecord.MapTo<KqDetail>();
                await _KqDetailRepository.InsertAsync(kqrecordDto);

            }

            else
            {
                //此功能暂不考虑
            }

        }


        /// <summary>
        /// 修改考勤记录(二次打卡)
        /// </summary>
        /// <param name="KqRecordId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(int KqRecordId, KqDetailEditDtos input)
        {

            //获得用户班次信息
            var KqShift = await _KqShiftRepository.FirstOrDefaultAsync(p => p.Id == input.KqShiftId);

            string NowYMD = DateTime.Now.ToString("yyyy/MM/dd");
            //班次上班时间
            DateTime TodayWorkTime = Convert.ToDateTime(NowYMD + " " + KqShift.WorkTime + ":00");
            //班次下班时间
            DateTime TodayClosingTime = Convert.ToDateTime(NowYMD + " " + KqShift.ClosingTime + ":00");

            //获得用户今天打卡记录信息
            var KqRecordDto = await _KqDetailRepository.FirstOrDefaultAsync(p => p.Id == KqRecordId);

            #region 不同打卡方式(微信扫码：0，警务通NFC：1，门禁：2)
            //微信打卡
            if (input.IsNFC == 0)
            {
                //根据用户使用微信打卡离设定打卡二维码之间的距离是否超过50m，来判断打卡是否有效


            }
            //警务通NFC打卡
            else if (input.IsNFC == 1)
            {

                //签到类型（QDType（正常：0，迟到：1，早退：2，缺勤：3，请假：4）），
                //当第一次打卡时间超过班次上班打卡时间
                if (KqRecordDto.QDWorkTime > TodayWorkTime)
                {
                    //当第一次打卡时间超过班次下班打卡时间
                    if (KqRecordDto.QDWorkTime > TodayClosingTime)
                    {
                        KqRecordDto.QDClosingTime = DateTime.Now;
                        KqRecordDto.QDType = 3;
                    }
                    else
                    {
                        KqRecordDto.QDClosingTime = DateTime.Now;
                        KqRecordDto.QDType = 1;
                    }
                }
                else
                {
                    KqRecordDto.QDClosingTime = DateTime.Now;
                    if (KqRecordDto.QDClosingTime < TodayClosingTime)
                    {
                        KqRecordDto.QDType = 2;
                    }
                    else
                    {
                        KqRecordDto.QDType = 0;
                    }
                }
                await _KqDetailRepository.UpdateAsync(KqRecordDto);

            }
            //门禁打卡
            else
            {
                //此功能暂不考虑
            }

            #endregion



        }

        //public async Task<PagedResultDto<KqDetailEditDto>> GetPagedAsync(GetKqDetailInputDto input)
        //{
        //    var entity =
        //        await _KqAllDeatilRepository.GetAllListAsync(
        //            p => p.QDTime > input.StartTime && p.QDTime < input.EndTime);

        //    return new {KqDetailForEidt= KqDetailForEidt }
        //}
    }

}
