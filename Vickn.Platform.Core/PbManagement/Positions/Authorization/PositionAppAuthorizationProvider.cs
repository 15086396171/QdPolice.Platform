/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.Authorization
* 类 名  称 :     PositionAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionAppAuthorizationProvider.cs
* 描      述 :      给岗位权限默认设置服务
* 创建时间 :     2018/5/6 14:16:38
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.Positions.Authorization
{
    /// <summary>
    /// 权限配置
    /// 给岗位权限默认设置服务
    /// See <see cref="PositionAppPermissions"/> for all permission names.
    /// </summary>
    public class PositionAppAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了岗位的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_PbManagement)
                ?? pages.CreateChildPermission(AppPermissions.Pages_PbManagement, L(AppPermissions.Pages_PbManagement));

            var position = entityNameModel.CreateChildPermission(PositionAppPermissions.Position, L("Position"));
            position.CreateChildPermission(PositionAppPermissions.Position_CreatePosition, L("CreatePosition"));
            position.CreateChildPermission(PositionAppPermissions.Position_EditPosition, L("EditPosition"));
            position.CreateChildPermission(PositionAppPermissions.Position_DeletePosition, L("DeletePosition"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}