using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.PbManagement.PositionPbMaps;

namespace Vickn.Platform.PbManagement.PbTitles.EntityMapper
{
    public class PositionPbMapCfg:EntityTypeConfiguration<PositionPbMap>
    {
        public PositionPbMapCfg()
        {
            ToTable("PositionPbMap", PlatformConsts.SchemaName.PbManagement);

        }
    }
}