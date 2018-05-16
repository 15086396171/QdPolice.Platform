/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.EntityMapper
* 类 名  称 :     UserPositionCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionCfg.cs
* 描      述 :     职位信息数据库映射配置
* 创建时间 :     2018/5/16 9:57:56
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

namespace Vickn.Platform.Zero.UserPositions.EntityMapper
{
	 /// <summary>
    /// 职位信息数据库映射配置
    /// </summary>
    public class UserPositionCfg : EntityTypeConfiguration<UserPosition>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public UserPositionCfg()
		{
		    ToTable("UserPosition", PlatformConsts.SchemaName.Default);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //		public IDbSet<UserPosition> UserPositions { get; set; }
            //		 modelBuilder.Configurations.Add(new UserPositionCfg());

		    //TODO: 自定义数据库映射



		    // 职位名称
			Property(a => a.PositionName).HasMaxLength(20);
		}
    }
}