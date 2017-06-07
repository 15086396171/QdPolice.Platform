
namespace Vickn.Platform.Users.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="UserAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class UserAppPermissions
    {

        /// <summary>
        /// 用户管理管理权限
        /// </summary>
        public const string User = "Pages.User";

        /// <summary>
        /// 用户管理创建权限
        /// </summary>
        public const string User_CreateUser = "Pages.User.CreateUser";
        /// <summary>
        /// 用户管理修改权限
        /// </summary>
        public const string User_EditUser = "Pages.User.EditUser";
        /// <summary>
        /// 用户管理删除权限
        /// </summary>
        public const string User_DeleteUser = "Pages.User.DeleteUser";

        /// <summary>
        /// 重置密码权限
        /// </summary>
        public const string User_ResetPasswordUser = "Pages.User.ResetPasswordUser";
    }

}

