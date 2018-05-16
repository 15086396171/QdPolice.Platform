﻿/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Dtos
* 类 名  称 :     GetUserPositionInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetUserPositionInput.cs
* 描      述 :     职位信息管理分页排序查询输入Dto
* 创建时间 :     2018/5/16 9:57:50
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.Zero.UserPositions.Dtos
{
     /// <summary>
    /// 职位信息管理查询Dto
    /// </summary>
    public class GetUserPositionInput : PagedAndSortedInputDto,IShouldNormalize
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