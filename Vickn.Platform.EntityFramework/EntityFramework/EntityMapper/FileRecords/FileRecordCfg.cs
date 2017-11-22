/*
* 命名空间 :     Vickn.Platform.FileRecords.EntityMapper
* 类 名  称 :     FileRecordCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordCfg.cs
* 描      述 :     文件记录数据库映射配置
* 创建时间 :     2017/8/13 22:00:25
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Vickn.Platform.EntityFramework;

namespace Vickn.Platform.FileRecords.EntityMapper
{
	 /// <summary>
    /// 文件记录数据库映射配置
    /// </summary>
    public class FileRecordCfg : EntityTypeConfiguration<FileRecord>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public FileRecordCfg()
		{
		    ToTable("FileRecord", PlatformConsts.SchemaName.Default);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    Property(p => p.FileId).HasMaxLength(128);
		    //TODO: 自定义数据库映射

		}
    }
}