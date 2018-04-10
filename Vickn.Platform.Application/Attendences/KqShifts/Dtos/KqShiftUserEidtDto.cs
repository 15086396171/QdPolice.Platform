using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqShifts;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Attendences.KqShifts.Dtos
{
    /// <summary>
    /// 考勤班次对应用户管理编辑Dto
    /// </summary>
    [AutoMap(typeof(KqShiftUser))]
    public class KqShiftUserEidtDto
    {
        /// <summary>
        /// 记录Id
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserListDto User { get; set; }
        /// <summary>
        /// 考勤班次Id
        /// </summary>
        public long? KqShiftId { get; set; }

    }
}
