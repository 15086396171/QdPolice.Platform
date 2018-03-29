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
    /// 考勤班次信息数据库映射配置
    /// </summary>
    public class KqShiftCfg:EntityTypeConfiguration<KqShift>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PlatformDbContext" /> ]
        /// </summary>
        public KqShiftCfg()
        {
            ///在数据库生成KqShift表名时，表名前加Attendance，如：表名前加Attendance.KqShift
            ToTable("KqShift", PlatformConsts.SchemaName.Attendance);
        }
    }
}
