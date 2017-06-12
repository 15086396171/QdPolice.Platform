/*
* 命名空间 :     Vickn.Platform.DataDictionaries.EntityMapper
* 类 名  称 :     DataDictionaryCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryCfg.cs
* 描      述 :     数据字典数据库映射配置
* 创建时间 :     2017/6/12 16:41:32
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
    /// 数据字典数据库映射配置
    /// </summary>
    public class DataDictionaryCfg : EntityTypeConfiguration<DataDictionary>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public DataDictionaryCfg()
        {
            ToTable("PlatformDataDictionary", PlatformConsts.SchemaName.Default);

            //TODO: 需要将以下文件注入到PlatformDbContext中

            //		public IDbSet<DataDictionary> DataDictionaries { get; set; }
            //		 modelBuilder.Configurations.Add(new DataDictionaryCfg());

            //TODO: 自定义数据库映射

            // 键名
            Property(a => a.Key).HasMaxLength(16);
            // 显示名
            Property(a => a.DisplayName).HasMaxLength(16);
            HasMany(p => p.DataDictionaryItems).WithRequired().HasForeignKey(p => p.DataDictionaryId);
        }
    }
}