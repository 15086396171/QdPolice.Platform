
namespace Vickn.Platform.OrganizationUnits.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="OrganizationUnitAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class OrganizationUnitAppPermissions
    {

        /// <summary>
        /// 组织管理管理权限
        /// </summary>
        public const string OrganizationUnit = "Pages.OrganizationUnit";

        /// <summary>
        /// 组织管理创建权限
        /// </summary>
        public const string OrganizationUnit_CreateOrganizationUnit = "Pages.OrganizationUnit.CreateOrganizationUnit";
        /// <summary>
        /// 组织管理修改权限
        /// </summary>
        public const string OrganizationUnit_EditOrganizationUnit = "Pages.OrganizationUnit.EditOrganizationUnit";
        /// <summary>
        /// 组织管理删除权限
        /// </summary>
        public const string OrganizationUnit_DeleteOrganizationUnit = "Pages.OrganizationUnit.DeleteOrganizationUnit";
    }

}

