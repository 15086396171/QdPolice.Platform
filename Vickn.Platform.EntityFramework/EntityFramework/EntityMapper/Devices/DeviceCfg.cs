/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.EntityMapper
* 类 名  称 :     DeviceCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceCfg.cs
* 描      述 :     设备数据库映射配置
* 创建时间 :     2018/2/4 16:27:07
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

namespace Vickn.Platform.HandheldTerminals.Devices.EntityMapper
{
	 /// <summary>
    /// 设备数据库映射配置
    /// </summary>
    public class DeviceCfg : EntityTypeConfiguration<Device>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public DeviceCfg()
		{
		    ToTable("Device", PlatformConsts.SchemaName.HandheldTerminal);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //		public IDbSet<Device> Devices { get; set; }
            //		 modelBuilder.Configurations.Add(new DeviceCfg());

		    //TODO: 自定义数据库映射

		    // IMEI
			Property(a => a.Imei).HasMaxLength(32);
		    // 编号
			Property(a => a.No).HasMaxLength(16);

		    HasRequired(p => p.User).WithMany().HasForeignKey(p => p.CreatorUserId);
		}
    }
}