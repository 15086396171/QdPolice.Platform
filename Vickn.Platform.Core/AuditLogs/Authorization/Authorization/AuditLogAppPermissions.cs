
namespace Vickn.Platform.AuditLogs.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="AuditLogAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class AuditLogAppPermissions
    {

        /// <summary>
        /// 组织管理管理权限
        /// </summary>
        public const string AuditLog = "Pages.AuditLog";

        /// <summary>
        /// 组织管理创建权限
        /// </summary>
        public const string AuditLog_CreateAuditLog = "Pages.AuditLog.CreateAuditLog";
        /// <summary>
        /// 组织管理修改权限
        /// </summary>
        public const string AuditLog_EditAuditLog = "Pages.AuditLog.EditAuditLog";
        /// <summary>
        /// 组织管理删除权限
        /// </summary>
        public const string AuditLog_DeleteAuditLog = "Pages.AuditLog.DeleteAuditLog";
    }

}

