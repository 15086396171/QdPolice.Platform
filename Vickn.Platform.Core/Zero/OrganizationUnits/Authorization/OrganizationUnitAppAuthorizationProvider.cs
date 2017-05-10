
// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-01-17T22:21:18. All Rights Reserved.
//<生成时间>2017-01-17T22:21:18</生成时间>

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;
using Vickn.Platform.OrganizationUnits.Authorization;

namespace Vickn.Platform.OrganizationUnits.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="OrganizationUnitAppPermissions"/> for all permission names.
    /// </summary>
    public class OrganizationUnitAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了组织 的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_SystemManage)
              ?? pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            var user = entityNameModel.CreateChildPermission(OrganizationUnitAppPermissions.OrganizationUnit, L("OrganizationUnit"));
            user.CreateChildPermission(OrganizationUnitAppPermissions.OrganizationUnit_CreateOrganizationUnit, L("CreateOrganizationUnit"));
            user.CreateChildPermission(OrganizationUnitAppPermissions.OrganizationUnit_EditOrganizationUnit, L("EditOrganizationUnit"));
            user.CreateChildPermission(OrganizationUnitAppPermissions.Pages_OrganizationUnit_ManageUser, L("OrganizationUnit.ManageUser"));
            user.CreateChildPermission(OrganizationUnitAppPermissions.OrganizationUnit_DeleteOrganizationUnit, L("DeleteOrganizationUnit"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }




}