/*
* 命名空间 :     Vickn.Platform.FileRecords.Dtos
* 类 名  称 :     GetFileRecordInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetFileRecordInput.cs
* 描      述 :     文件记录管理分页排序查询输入Dto
* 创建时间 :     2017/8/13 22:00:23
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;
 
namespace Vickn.Platform.FileRecords.Dtos
{
     /// <summary>
    /// 文件记录管理查询Dto
    /// </summary>
    public class GetFileRecordInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

        public string FileId { get; set; }

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
