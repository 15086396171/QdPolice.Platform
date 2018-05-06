/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles.Authorization
* 类 名  称 :     PbTitleAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleAppAuthorizationProvider.cs
* 描      述 :      给排班标题权限默认设置服务
* 创建时间 :     2018/5/6 14:40:33
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.PbTitles.Authorization
{
    /// <summary>
    /// 权限配置
    /// 给排班标题权限默认设置服务
    /// See <see cref="PbTitleAppPermissions"/> for all permission names.
    /// </summary>
    public class PbTitleAppAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了排班标题的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_PbManagement)
                ?? pages.CreateChildPermission(AppPermissions.Pages_PbManagement, L(AppPermissions.Pages_PbManagement));

            var pbTitle = entityNameModel.CreateChildPermission(PbTitleAppPermissions.PbTitle, L("PbTitle"));
            pbTitle.CreateChildPermission(PbTitleAppPermissions.PbTitle_CreatePbTitle, L("CreatePbTitle"));
            pbTitle.CreateChildPermission(PbTitleAppPermissions.PbTitle_EditPbTitle, L("EditPbTitle"));
            pbTitle.CreateChildPermission(PbTitleAppPermissions.PbTitle_DeletePbTitle, L("DeletePbTitle"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}