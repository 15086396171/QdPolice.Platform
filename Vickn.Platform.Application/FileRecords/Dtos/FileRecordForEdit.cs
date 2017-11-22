/*
* 命名空间 :     Vickn.Platform.FileRecords.Dtos
* 类 名  称 :     FileRecordForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordForEdit.cs
* 描      述 :     用于获取添加或编辑 文件记录管理时使用的Dto
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
    /// 用于获取添加或编辑 文件记录管理时使用的Dto
    /// </summary>
    public class FileRecordForEdit
    {
		public FileRecordEditDto FileRecordEditDto { get; set; } 
    }
}
