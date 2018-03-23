using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances
{
    /// <summary>
    /// 考勤签到管理
    /// </summary>
    public class DetailManager: IDomainService
    {
        private readonly IRepository<Detail> _AttendanceDetailRepository;

        /// <summary>
        /// 初始化DetailManager管理实例
        /// </summary>
        public DetailManager(IRepository<Detail> AttendanceDetailRepository)
        {
            _AttendanceDetailRepository = AttendanceDetailRepository;
        }

       
    }
}
