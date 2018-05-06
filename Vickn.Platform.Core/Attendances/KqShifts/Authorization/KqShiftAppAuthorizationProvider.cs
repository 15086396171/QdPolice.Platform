using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Attendances.KqShifts.Authorization
{
    /// <summary>
    /// 权限配置
    /// 给设备权限默认设置服务
    /// See <see cref="DeviceAppPermissions"/> for all permission names.
	/// </summary>
    public class KqShiftAppAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了考勤班次的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_AttendanceManage)
                ?? pages.CreateChildPermission(AppPermissions.Pages_AttendanceManage, L(AppPermissions.Pages_AttendanceManage));

            var KqShiftRecord = entityNameModel.CreateChildPermission(KqShiftAppPermissions.KqShift, L("KqShift"));
            KqShiftRecord.CreateChildPermission(KqShiftAppPermissions.KqShift_CreateKqShift, L("CreateKqShift"));
            KqShiftRecord.CreateChildPermission(KqShiftAppPermissions.KqShift_EditKqShift, L("EditKqShift"));
            KqShiftRecord.CreateChildPermission(KqShiftAppPermissions.KqShift_DeleteKqShift, L("DeleteKqShift"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
