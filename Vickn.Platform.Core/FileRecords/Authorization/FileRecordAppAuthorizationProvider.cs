/*
* 命名空间 :     Vickn.Platform.FileRecords.Authorization
* 类 名  称 :     FileRecordAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordAppAuthorizationProvider.cs
* 描      述 :      给文件记录权限默认设置服务
* 创建时间 :     2017/8/13 22:00:20
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.FileRecords.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给文件记录权限默认设置服务
    /// See <see cref="FileRecordAppPermissions"/> for all permission names.
	/// </summary>
    public class FileRecordAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了文件记录的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages) 
                ?? pages.CreateChildPermission(AppPermissions.Pages, L("Pages"));

            var fileRecord = entityNameModel.CreateChildPermission(FileRecordAppPermissions.FileRecord , L("FileRecord"));
            fileRecord.CreateChildPermission(FileRecordAppPermissions.FileRecord_CreateFileRecord, L("CreateFileRecord"));
            fileRecord.CreateChildPermission(FileRecordAppPermissions.FileRecord_EditFileRecord, L("EditFileRecord"));           
            fileRecord.CreateChildPermission(FileRecordAppPermissions. FileRecord_DeleteFileRecord, L("DeleteFileRecord"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}