using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.KqShifts.Authorization
{
    public static class KqShiftAppPermissions
    {
        /// <summary>
        /// 班次管理权限
        /// </summary>
        public const string KqShift = "Pages.KqShift";

        /// <summary>
        /// 班次管理创建权限
        /// </summary>
        public const string KqShift_CreateKqShift = "Pages.KqShift.CreateKqShift";

        /// <summary>
        /// 班次管理修改权限
        /// </summary>
        public const string KqShift_EditKqShift = "Pages.KqShift.EditKqShift";

        /// <summary>
        /// 班次管理删除权限
        /// </summary>
        public const string KqShift_DeleteKqShift = "Pages.KqShift.DeleteKqShift";
    }
}
