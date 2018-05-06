using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.Attendances.KqShifts;

namespace Vickn.Platform.EntityFramework.EntityMapper.Attendances.KqShifts
{

    /// <summary>
    /// 考勤班次对应用户信息数据库映射配置
    /// </summary>
    public class KqShiftUserCfg:EntityTypeConfiguration<KqShiftUser>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public KqShiftUserCfg()
        {
            ToTable("KqShiftUser", PlatformConsts.SchemaName.Attendance);
        }
    }
}
