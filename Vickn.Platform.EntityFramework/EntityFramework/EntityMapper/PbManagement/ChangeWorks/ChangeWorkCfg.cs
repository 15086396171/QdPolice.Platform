/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.EntityMapper
* 类 名  称 :     ChangeWorkCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkCfg.cs
* 描      述 :     换班数据库映射配置
* 创建时间 :     2018/5/14 9:16:05
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

namespace Vickn.Platform.PbManagement.ChangeWorks.EntityMapper
{
	 /// <summary>
    /// 换班数据库映射配置
    /// </summary>
    public class ChangeWorkCfg : EntityTypeConfiguration<ChangeWork>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public ChangeWorkCfg()
		{
		    ToTable("ChangeWork", PlatformConsts.SchemaName.Default);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //		public IDbSet<ChangeWork> ChangeWorks { get; set; }
            //		 modelBuilder.Configurations.Add(new ChangeWorkCfg());

		    //TODO: 自定义数据库映射



		}
    }
}