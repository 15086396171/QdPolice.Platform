﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Schedules.PlatoonGroups;

namespace Vickn.Platform.EntityFramework.EntityMapper.Schedules.PlatoonGroups
{
 

    /// <summary>
    /// 排班组数据库映射配置
    /// </summary>
    public class GroupMemberCfg : EntityTypeConfiguration<GroupMember>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public GroupMemberCfg()
        {
            ToTable("GroupMember", PlatformConsts.SchemaName.Schedule);

            //TODO: 需要将以下文件注入到PlatformDbContext中

            //		public IDbSet<PlatoonGroup> PlatoonGroups { get; set; }
            //		 modelBuilder.Configurations.Add(new PlatoonGroupCfg());

            //TODO: 自定义数据库映射



        }
    }
}
