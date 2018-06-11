﻿using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
   public class GetKqStatisticInputDto : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

        /// <summary>
        /// 模糊查询用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 签到类型
        /// </summary>
        public string IsUnusual { get; set; }

        /// <summary>
        /// 签到班次名称
        /// </summary>
        public string KqShiftName { get; set; }
        

        /// <summary>
        /// 用于排序的默认值
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id Desc";
            }
        }
    }
}
