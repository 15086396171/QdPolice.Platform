using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances;

namespace Vickn.Platform.Attendences.Dtos
{
    [AutoMap(typeof(Detail))]
    public class AttendancesEditDto 
    {

       public AttendanceDto AttendanceDto { get; set; }
    }
}
