/*
* 命名空间 :     Vickn.Platform.DataDictionaries.EntityMapper
* 类 名  称 :     DataDictionaryItemCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemCfg.cs
* 描      述 :     数据字典项数据库映射配置
* 创建时间 :     2017/6/12 16:57:19
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

namespace Vickn.Platform.DataDictionaries.EntityMapper
{
	 /// <summary>
    /// 数据字典项数据库映射配置
    /// </summary>
    public class DataDictionaryItemCfg : EntityTypeConfiguration<DataDictionaryItem>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public DataDictionaryItemCfg()
		{
		    ToTable("PlatformDataDictionaryItem", PlatformConsts.SchemaName.Default);
 
		    // 值
			Property(a => a.Value).HasMaxLength(32);
			Property(a => a.DisplayName).HasMaxLength(32);
		}
    }
}