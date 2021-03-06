﻿/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
* 类 名  称 :     GetAppWhiteListInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetAppWhiteListInput.cs
* 描      述 :     应用白名单管理分页排序查询输入Dto
* 创建时间 :     2018/2/5 15:11:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
{
     /// <summary>
    /// 应用白名单管理查询Dto
    /// </summary>
    public class GetAppWhiteListInput : PagedAndSortedInputDto,IShouldNormalize
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
