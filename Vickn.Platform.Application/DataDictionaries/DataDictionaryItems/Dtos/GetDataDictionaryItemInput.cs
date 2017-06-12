/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     GetDataDictionaryItemInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetDataDictionaryItemInput.cs
* 描      述 :     数据字典项管理分页排序查询输入Dto
* 创建时间 :     2017/6/12 16:57:19
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.DataDictionaries.Dtos
{
     /// <summary>
    /// 数据字典项管理查询Dto
    /// </summary>
    public class GetDataDictionaryItemInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        /// <summary>
        /// 键Id
        /// </summary>
         public int DataDictionaryId { get; set; }

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
