/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.Authorization
* 类 名  称 :     ChangeWorkAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkAppAuthorizationProvider.cs
* 描      述 :      给换班权限默认设置服务
* 创建时间 :     2018/5/14 9:16:00
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.ChangeWorks.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给换班权限默认设置服务
    /// See <see cref="ChangeWorkAppPermissions"/> for all permission names.
	/// </summary>
    public class ChangeWorkAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了换班的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_PbManagement) 
                ?? pages.CreateChildPermission(AppPermissions.Pages, L("Pages_PbManagement"));

            var changeWork = entityNameModel.CreateChildPermission(ChangeWorkAppPermissions.ChangeWork , L("ChangeWork"));
            changeWork.CreateChildPermission(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork, L("CreateChangeWork"));
            changeWork.CreateChildPermission(ChangeWorkAppPermissions.ChangeWork_EditChangeWork, L("EditChangeWork"));           
            changeWork.CreateChildPermission(ChangeWorkAppPermissions. ChangeWork_DeleteChangeWork, L("DeleteChangeWork"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}