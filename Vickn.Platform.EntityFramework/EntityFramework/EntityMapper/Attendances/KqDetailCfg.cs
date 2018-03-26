using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KQDetails;

namespace Vickn.Platform.EntityFramework.EntityMapper.Attendances
{

    /// <summary>
    /// 黔东明细数据库映射配置
    /// </summary>
   public class KqDetailCfg : EntityTypeConfiguration<KqDetail>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public KqDetailCfg()
        {
            ToTable("KqDetail", PlatformConsts.SchemaName.Attendance);

            //TODO: 需要将以下文件注入到PlatformDbContext中

            //TODO: 自定义数据库映射

         
        }
    }
}
