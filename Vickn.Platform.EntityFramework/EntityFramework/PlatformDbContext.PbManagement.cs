using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.PbManagement.Positions;
using Vickn.Platform.PbManagement.Positions.EntityMapper;

namespace Vickn.Platform.EntityFramework
{
    public partial class PlatformDbContext
    {
        public IDbSet<Position> Positions { get; set; }

        private void PbManagementConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PositionCfg());
        }
    }
}
