/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.EntityMapper
* 类 名  称 :     AppWhiteListCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListCfg.cs
* 描      述 :     应用白名单数据库映射配置
* 创建时间 :     2018/2/5 15:11:42
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

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists.EntityMapper
{
	 /// <summary>
    /// 应用白名单数据库映射配置
    /// </summary>
    public class AppWhiteListCfg : EntityTypeConfiguration<AppWhiteList>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public AppWhiteListCfg()
		{
		    ToTable("AppWhiteList", PlatformConsts.SchemaName.HandheldTerminal);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //TODO: 自定义数据库映射

		    // 应用名称
			Property(a => a.Name).HasMaxLength(64);
		    // 包名
			Property(a => a.PackageName).HasMaxLength(64);
		    // 文件
			Property(a => a.Src).HasMaxLength(128);
		    Property(a => a.Version).HasMaxLength(10);
		}
    }
}