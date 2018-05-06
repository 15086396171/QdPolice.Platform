/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles.EntityMapper
* 类 名  称 :     PbTitleCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleCfg.cs
* 描      述 :     排班标题数据库映射配置
* 创建时间 :     2018/5/6 14:40:39
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
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.PbManagement.PositionPbTimes;

namespace Vickn.Platform.PbManagement.PbTitles.EntityMapper
{
	 /// <summary>
    /// 排班标题数据库映射配置
    /// </summary>
    public class PositionPbTimeCfg : EntityTypeConfiguration<PositionPbTime>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public PositionPbTimeCfg()
		{
		    ToTable("PositionPbTime", PlatformConsts.SchemaName.PbManagement);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //TODO: 自定义数据库映射

	
		}
    }
}