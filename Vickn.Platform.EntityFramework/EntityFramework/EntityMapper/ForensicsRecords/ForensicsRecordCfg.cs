/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.EntityMapper
* 类 名  称 :     ForensicsRecordCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordCfg.cs
* 描      述 :     取证记录数据库映射配置
* 创建时间 :     2018/2/5 17:40:11
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

namespace Vickn.Platform.HandheldTerminals.EntityMapper
{
	 /// <summary>
    /// 取证记录数据库映射配置
    /// </summary>
    public class ForensicsRecordCfg : EntityTypeConfiguration<ForensicsRecord>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public ForensicsRecordCfg()
		{
		    ToTable("ForensicsRecord", PlatformConsts.SchemaName.HandheldTerminal);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //TODO: 自定义数据库映射

		    // 路径
			Property(a => a.Src).HasMaxLength(512);
		    // 模式
			Property(a => a.Mode).HasMaxLength(16);
		    // 描述
			Property(a => a.Des).HasMaxLength(128);
		    HasRequired(p => p.Device).WithMany().HasForeignKey(p => p.DeviceId);
		}
    }
}