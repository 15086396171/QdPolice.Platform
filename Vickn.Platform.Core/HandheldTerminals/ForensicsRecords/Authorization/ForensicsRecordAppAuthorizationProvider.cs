/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Authorization
* 类 名  称 :     ForensicsRecordAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordAppAuthorizationProvider.cs
* 描      述 :      给取证记录权限默认设置服务
* 创建时间 :     2018/2/5 17:40:04
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.HandheldTerminals.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给取证记录权限默认设置服务
    /// See <see cref="ForensicsRecordAppPermissions"/> for all permission names.
	/// </summary>
    public class ForensicsRecordAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了取证记录的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_HandheldTerminal) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_HandheldTerminal, L(AppPermissions.Pages_HandheldTerminal));

            var forensicsRecord = entityNameModel.CreateChildPermission(ForensicsRecordAppPermissions.ForensicsRecord , L("ForensicsRecord"));
            forensicsRecord.CreateChildPermission(ForensicsRecordAppPermissions.ForensicsRecord_CreateForensicsRecord, L("CreateForensicsRecord"));
            forensicsRecord.CreateChildPermission(ForensicsRecordAppPermissions.ForensicsRecord_EditForensicsRecord, L("EditForensicsRecord"));           
            forensicsRecord.CreateChildPermission(ForensicsRecordAppPermissions. ForensicsRecord_DeleteForensicsRecord, L("DeleteForensicsRecord"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}