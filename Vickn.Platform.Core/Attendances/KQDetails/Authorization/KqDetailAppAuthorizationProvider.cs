using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Attendances.KqDetails.Authorization
{
   public class KqDetailAppAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了考勤机信息的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_AttendanceManage)
                                  ?? pages.CreateChildPermission(AppPermissions.Pages_AttendanceManage, L(AppPermissions.Pages_AttendanceManage));

            var KqStatisticRecord = entityNameModel.CreateChildPermission(KqDetailAppPermissions.KqDetail, L("KqDetail"));

        }

        private ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
