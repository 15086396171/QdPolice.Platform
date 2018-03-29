using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqMachines;

namespace Vickn.Platform.EntityFramework.EntityMapper.Attendances.Kqmachines
{
    /// <summary>
    /// 考勤机信息数据库映射配置
    /// </summary>
    public class KqMachineCfg : EntityTypeConfiguration<KqMachine>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public KqMachineCfg()
        {
            ToTable("KqMachine", PlatformConsts.SchemaName.Attendance);

            
        }


    }
}
