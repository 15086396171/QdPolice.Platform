/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs.Dtos
* 类 名  称 :     GetPositionPbInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPositionPbInput.cs
* 描      述 :     单个岗位下排班时间管理分页排序查询输入Dto
* 创建时间 :     2018/5/6 17:14:51
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
     /// <summary>
    /// 单个岗位下排班时间管理查询Dto
    /// </summary>
    public class GetPositionPbInput : PagedAndSortedInputDto,IShouldNormalize
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
