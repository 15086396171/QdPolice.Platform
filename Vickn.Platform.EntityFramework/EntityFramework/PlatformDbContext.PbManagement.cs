using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.PbManagement.ChangeWorks;
using Vickn.Platform.PbManagement.ChangeWorks.EntityMapper;
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.PbManagement.PbTitles;
using Vickn.Platform.PbManagement.PbTitles.EntityMapper;
using Vickn.Platform.PbManagement.PositionPbMaps;
using Vickn.Platform.PbManagement.PositionPbs;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.Positions;
using Vickn.Platform.PbManagement.Positions.EntityMapper;

namespace Vickn.Platform.EntityFramework
{
    public partial class PlatformDbContext
    {
        public IDbSet<Position> Positions { get; set; }

        public IDbSet<PbTitle> PbTitles { get; set; }

        public IDbSet<PbPosition> PbPositions { get; set; }

        public IDbSet<PositionPb> PositionPbs { get; set; }

        public IDbSet<PositionPbTime> PositionPbTimes { get; set; }

        public IDbSet<PositionPbMap> PbTimes { get; set; }

        public IDbSet<ChangeWork> ChangeWorks { get; set; }

       

        private void PbManagementConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PositionCfg());
            modelBuilder.Configurations.Add(new PbTitleCfg());
            modelBuilder.Configurations.Add(new PbPositionCfg());
            modelBuilder.Configurations.Add(new PositionPbCfg());
            modelBuilder.Configurations.Add(new PositionPbTimeCfg());
            modelBuilder.Configurations.Add(new PositionPbMapCfg());
            modelBuilder.Configurations.Add(new ChangeWorkCfg());

        }
    }
}
