/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.EntityMapper
* 类 名  称 :     PositionCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionCfg.cs
* 描      述 :     岗位数据库映射配置
* 创建时间 :     2018/5/6 14:16:45
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

namespace Vickn.Platform.PbManagement.Positions.EntityMapper
{
	 /// <summary>
    /// 岗位数据库映射配置
    /// </summary>
    public class PositionCfg : EntityTypeConfiguration<Position>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public PositionCfg()
		{
		    ToTable("Position", PlatformConsts.SchemaName.PbManagement);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //TODO: 自定义数据库映射
		    // 岗位名称
			Property(a => a.Name).HasMaxLength(16);
		}
    }
}