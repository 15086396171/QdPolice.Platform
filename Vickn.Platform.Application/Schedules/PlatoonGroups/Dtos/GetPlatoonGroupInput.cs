/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Dtos
* 类 名  称 :     GetPlatoonGroupInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPlatoonGroupInput.cs
* 描      述 :     排班组管理分页排序查询输入Dto
* 创建时间 :     2018/5/4 15:19:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.Schedules.PlatoonGroups.Dtos
{
     /// <summary>
    /// 排班组管理查询Dto
    /// </summary>
    public class GetPlatoonGroupInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

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
