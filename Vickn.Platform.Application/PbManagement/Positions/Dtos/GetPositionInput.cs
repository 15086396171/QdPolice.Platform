﻿/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.Dtos
* 类 名  称 :     GetPositionInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPositionInput.cs
* 描      述 :     岗位管理分页排序查询输入Dto
* 创建时间 :     2018/5/6 14:16:40
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.PbManagement.Positions.Dtos
{
     /// <summary>
    /// 岗位管理查询Dto
    /// </summary>
    public class GetPositionInput : PagedAndSortedInputDto,IShouldNormalize
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
