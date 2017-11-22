/*
* 命名空间 :     Vickn.Platform.FileRecords.Dtos
* 类 名  称 :     GetFileRecordInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetFileRecordInput.cs
* 描      述 :     文件记录管理Dto
* 创建时间 :     2017/8/13 22:00:24
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.FileRecords.Dtos
{
    /// <summary>
    /// 文件记录管理Dto
    /// </summary>
    [AutoMap(typeof(FileRecord))]
    public class FileRecordDto : EntityDto<int>
    {
        /// <summary>
        /// 标记在其他文件中的文件id
        /// </summary>
		[DisplayName("标记在其他文件中的文件id")]
        public string FileId { get; set; }

        /// <summary>
        /// 文件本地保存地址
        /// </summary>
		[DisplayName("文件本地保存地址")]
        public string Url { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
		[DisplayName("文件名称")]
        public string Name { get; set; }

        public string Src => Url;

    }
}
