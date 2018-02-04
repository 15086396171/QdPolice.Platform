/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Dtos
* 类 名  称 :     GetDeviceInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetDeviceInput.cs
* 描      述 :     设备管理分页排序查询输入Dto
* 创建时间 :     2018/2/4 16:27:03
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.HandheldTerminals.Devices.Dtos
{
     /// <summary>
    /// 设备管理查询Dto
    /// </summary>
    public class GetDeviceInput : PagedAndSortedInputDto,IShouldNormalize
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
