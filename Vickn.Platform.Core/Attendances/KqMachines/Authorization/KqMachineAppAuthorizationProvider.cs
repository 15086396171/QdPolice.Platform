using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqMachines.Authorization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Attendances.KqMachines.Authorization
{
    /// <summary>
    /// 权限配置
    /// 给设备权限默认设置服务
    /// </summary>
   public class KqMachineAppAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了考勤机信息的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_AttendanceManage)
                                  ?? pages.CreateChildPermission(AppPermissions.Pages_AttendanceManage, L(AppPermissions.Pages_AttendanceManage));

            var KqMachineRecord = entityNameModel.CreateChildPermission(KqMachineAppPermissions.KqMachine,L("KqMachine"));
            KqMachineRecord.CreateChildPermission(KqMachineAppPermissions.KqMachine_CreateKqMachine, L("CreateKqMachine"));
            KqMachineRecord.CreateChildPermission(KqMachineAppPermissions.KqMachine_EditKqMachine, L("EditKqMachine"));
            KqMachineRecord.CreateChildPermission(KqMachineAppPermissions.KqMachine_DeleteKqMachine, L("DeleteKqMachine"));
        }

        private ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
