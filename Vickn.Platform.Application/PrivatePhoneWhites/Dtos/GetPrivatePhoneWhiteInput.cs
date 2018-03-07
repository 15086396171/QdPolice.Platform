/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.Dtos
* 类 名  称 :     GetPrivatePhoneWhiteInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPrivatePhoneWhiteInput.cs
* 描      述 :     个人白名单管理分页排序查询输入Dto
* 创建时间 :     2018/2/23 14:15:11
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.PrivatePhoneWhites.Dtos
{
     /// <summary>
    /// 个人白名单管理查询Dto
    /// </summary>
    public class GetPrivatePhoneWhiteInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public long UserId { get; set; }

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
