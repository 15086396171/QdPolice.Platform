/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.EntityMapper
* 类 名  称 :     SchedulingPostCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostCfg.cs
* 描      述 :     岗位设置数据库映射配置
* 创建时间 :     2018/5/3 15:40:50
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

namespace Vickn.Platform.Schedules.SchedulingPosts.EntityMapper
{
	 /// <summary>
    /// 岗位设置数据库映射配置
    /// </summary>
    public class SchedulingPostCfg : EntityTypeConfiguration<SchedulingPost>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public SchedulingPostCfg()
		{
		    ToTable("SchedulingPost", PlatformConsts.SchemaName.Schedule);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //		public IDbSet<SchedulingPost> SchedulingPosts { get; set; }
            //		 modelBuilder.Configurations.Add(new SchedulingPostCfg());

		    //TODO: 自定义数据库映射



		}
    }
}