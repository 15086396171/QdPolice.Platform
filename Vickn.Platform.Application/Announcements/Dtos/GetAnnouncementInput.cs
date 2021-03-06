﻿/*
* 命名空间 :     Vickn.Platform.Announcements.Dtos
* 类 名  称 :     GetAnnouncementInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetAnnouncementInput.cs
* 描      述 :     通知公告管理分页排序查询输入Dto
* 创建时间 :     2018/2/24 11:42:57
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.Announcements.Dtos
{
     /// <summary>
    /// 通知公告管理查询Dto
    /// </summary>
    public class GetAnnouncementInput : PagedAndSortedInputDto,IShouldNormalize
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
