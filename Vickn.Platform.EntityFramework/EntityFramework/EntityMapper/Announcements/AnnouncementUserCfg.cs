/*
* 命名空间 :     Vickn.Platform.Announcements.EntityMapper
* 类 名  称 :     AnnouncementCfg
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementCfg.cs
* 描      述 :     通知公告数据库映射配置
* 创建时间 :     2018/2/24 11:43:03
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

namespace Vickn.Platform.Announcements.EntityMapper
{
	 /// <summary>
    /// 通知公告数据库映射配置
    /// </summary>
    public class AnnouncementUserCfg : EntityTypeConfiguration<AnnouncementUser>
    {
       	/// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
		public AnnouncementUserCfg()
		{
		    ToTable("AnnouncementUser", PlatformConsts.SchemaName.Business);
 
		    //TODO: 需要将以下文件注入到PlatformDbContext中

		    //TODO: 自定义数据库映射

		    // 标题
		    HasRequired(p => p.User).WithMany().HasForeignKey(p => p.UserId);
		}
    }
}