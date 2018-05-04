/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.EntityMapper
* 类 名  称 :     PlatoonGroupCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupCfg.cs
* 描      述 :     排班组数据库映射配置
* 创建时间 :     2018/5/3 17:22:53
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

namespace Vickn.Platform.Schedules.PlatoonGroups.EntityMapper
{
	 /// <summary>
    /// 排班组数据库映射配置
    /// </summary>
    public class PlatoonGroupCfg : EntityTypeConfiguration<PlatoonGroup>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public PlatoonGroupCfg()
		{
		    ToTable("PlatoonGroup", PlatformConsts.SchemaName.Schedule);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //		public IDbSet<PlatoonGroup> PlatoonGroups { get; set; }
            //		 modelBuilder.Configurations.Add(new PlatoonGroupCfg());

		    //TODO: 自定义数据库映射



		    // 排班组名称
			Property(a => a.PlatoonGroupName).HasMaxLength(100);
		    // 组长名称
			Property(a => a.GroupLeaderName).HasMaxLength(100);

           
        }
    }
}