using System.Collections.Generic;
using Vickn.Platform.MainTenance.Caching.Dto;

namespace Vickn.Platform.Web.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}