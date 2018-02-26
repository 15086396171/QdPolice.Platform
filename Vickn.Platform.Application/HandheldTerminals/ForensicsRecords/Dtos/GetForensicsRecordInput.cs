/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Dtos
* 类 名  称 :     GetForensicsRecordInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetForensicsRecordInput.cs
* 描      述 :     取证记录管理分页排序查询输入Dto
* 创建时间 :     2018/2/5 17:40:07
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.HandheldTerminals.Dtos
{
     /// <summary>
    /// 取证记录管理查询Dto
    /// </summary>
    public class GetForensicsRecordInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public ForensicsRecordType? Type { get; set; }

        public long DeviceId { get; set; }

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
