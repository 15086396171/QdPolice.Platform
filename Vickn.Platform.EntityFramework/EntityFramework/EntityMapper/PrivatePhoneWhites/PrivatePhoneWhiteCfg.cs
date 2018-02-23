/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.EntityMapper
* 类 名  称 :     PrivatePhoneWhiteCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteCfg.cs
* 描      述 :     个人白名单数据库映射配置
* 创建时间 :     2018/2/23 14:15:15
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

namespace Vickn.Platform.PrivatePhoneWhites.EntityMapper
{
	 /// <summary>
    /// 个人白名单数据库映射配置
    /// </summary>
    public class PrivatePhoneWhiteCfg : EntityTypeConfiguration<PrivatePhoneWhite>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public PrivatePhoneWhiteCfg()
		{
		    ToTable("PrivatePhoneWhite", PlatformConsts.SchemaName.Business);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中


		    //TODO: 自定义数据库映射

		    HasRequired(p => p.User).WithMany().HasForeignKey(p => p.UserId);
		    // 姓名
			Property(a => a.Name).HasMaxLength(16);
		    // 电话号码
			Property(a => a.PhoneNumber).HasMaxLength(16);
		}
    }
}