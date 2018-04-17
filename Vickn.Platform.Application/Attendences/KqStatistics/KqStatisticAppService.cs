using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendences.KqStatistics.Dtos;

namespace Vickn.Platform.Attendences.KqStatistics
{
    public class KqStatisticAppService : IKqStatisticAppService
    {
        private readonly IRepository<KqDetail> _KqDetailRepository;

        public KqStatisticAppService(IRepository<KqDetail> KqDetailRepository)
        {
            _KqDetailRepository = KqDetailRepository;
        }


        /// <summary>
        /// 考勤统计DTo
        /// </summary>
        public async Task<List<KqStatisticEditDto>> GetKqStatisticAsync(GetKqStatisticInputDto input)
        {
            List<KqStatisticEditDto> KqRecordlist = new List<KqStatisticEditDto>();
            if (input == null)
            {
                //默认查询当天的数据
                var NowKqList = await _KqDetailRepository.GetAllListAsync(p => p.QDWorkTime > DateTime.Today);

                for (int i = 0; i < NowKqList.Count(); i++)
                {
                    KqStatisticEditDto list = new KqStatisticEditDto();
                    list.NormalDay = NowKqList[i].QDType == 0 ? 1 : 0;
                    list.LateDay = NowKqList[i].QDType == 1 ? 1 : 0;
                    list.LeaveEarlyDay = NowKqList[i].QDType == 2 ? 1 : 0;
                    list.AbsenteeismDay = NowKqList[i].QDType == 3 ? 1 : 0;
                    list.UserName = input.UserName;
                    list.GroupName = "";
                    KqRecordlist.Add(list);
                }
            }
            else
            {


                if (!string.IsNullOrEmpty(input.UserName))
                {
                    var KqList = await _KqDetailRepository.GetAllListAsync(p => p.UserName == input.UserName || p.QDWorkTime < input.StartTime && p.QDWorkTime < input.EndTime);
                    
                    for (int i = 0; i < KqList.Count(); i++)
                    {
                        KqStatisticEditDto list = new KqStatisticEditDto();
                        list.NormalDay = list.NormalDay;
                        list.LateDay = KqList[i].QDType == 1 ? 1 : 0;
                        list.LeaveEarlyDay = KqList[i].QDType == 2 ? 1 : 0;
                        list.AbsenteeismDay = KqList[i].QDType == 3 ? 1 : 0;
                        list.UserName = input.UserName;
                        list.GroupName = "";
                        KqRecordlist.Add(list);
                    }
                }

                if (input.StartTime == null)
                {
                    var KqList = await _KqDetailRepository.GetAllListAsync(p => p.QDWorkTime < input.StartTime && p.QDWorkTime < input.EndTime);
                    for (int i = 0; i < KqList.Count(); i++)
                    {
                        KqStatisticEditDto list = new KqStatisticEditDto();
                        list.NormalDay = KqList[i].QDType == 0 ? 1 : 0;
                        list.LateDay = KqList[i].QDType == 1 ? 1 : 0;
                        list.LeaveEarlyDay = KqList[i].QDType == 2 ? 1 : 0;
                        list.AbsenteeismDay = KqList[i].QDType == 3 ? 1 : 0;
                        list.UserName = input.UserName;
                        list.GroupName = "";
                        KqRecordlist.Add(list);
                    }
                }



            }




            return KqRecordlist;

        }



        /// <summary>
        /// app获取考勤Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<KqAppResultYMdDto>> GetAppKqStatisticAsync(GetKqStatisticAppDto input)
        {
            var StartTime = input.Date + "/01 00:00:00";
            DateTime StartTimes = Convert.ToDateTime(StartTime);
            DateTime EndTimes = StartTimes.AddMonths(1).AddHours(-1);
            var entity = await _KqDetailRepository.GetAllListAsync(p =>
                p.UserName == input.UserName && p.QDWorkTime > StartTimes && p.QDWorkTime < EndTimes);

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

        public async Task<List<KqStatisticYMdDto>> GetAppKqRecordAsync(GetKqStatisticAppDto input)
        {
            var StartTime = input.Date + " 00:00:00";
            DateTime StartTimes = Convert.ToDateTime(StartTime);
            DateTime EndTimes = StartTimes.AddDays(1).AddSeconds(-1);
            var entity = await _KqDetailRepository.GetAllListAsync(p =>
                p.UserName == input.UserName && p.QDWorkTime > StartTimes && p.QDWorkTime < EndTimes);

            List<KqStatisticYMdDto> kqList = new List<KqStatisticYMdDto>();
            for (int i = 0; i < entity.Count(); i++)
            {
                KqStatisticYMdDto list = new KqStatisticYMdDto();
               
                list.DateWork = entity[i].QDWorkTime.ToString("HH:mm:ss");
                list.DateColsing = entity[i].QDClosingTime.ToString("HH:mm:ss");
               

                kqList.Add(list);

            }

            return kqList;
        }
    }
}
