namespace Vickn.Platform
{
    public static class PlatformConsts
    {
        public const string LocalizationSourceName = "Platform-zh-CN";
        //public const string LocalizationSourceName = "Platform-es";

        public const string AppName = "Vickn后台管理系统";
        public const int DefaultPageSize = 15;
        public const int MaxPageSize = 100;

        /// <summary>
        /// 显示名称的最大长度
        /// </summary>
        public const int MaxDisplayNameLength = 64;

        /// <summary>
        /// 用户名的最大长度
        /// </summary>
        public const int MaxUserNameLength = 32;

        /// <summary>
        /// 是否启用组织
        /// </summary>
        public const bool EnableOrganizationUnit = true;

        /// <summary>
        /// 数据库架构名
        /// </summary>
        public static class SchemaName
        {
            /// <summary>
            /// 基础设置
            /// </summary>
            public const string Default = "dbo";

            public const string Basic = "Basic";

            /// <summary>
            /// 模块管理
            /// </summary>
            public const string Moudle = "Moudle";

            /// <summary>
            /// 网站设置
            /// </summary>
            public const string WebSetting = "WebSetting";
            /// <summary>
            /// 用于对多对表关系的结构
            /// </summary>
            public const string HasMany = "HasMany";

            /// <summary>
            /// 业务
            /// </summary>
            public const string Business = "Business";
        }
        public static class UserConst
        {
            public const string DefaultAdminUserName = "admin";
        }
        /// <summary>
        /// 通知系统的常量管理
        /// </summary>
        public static class NotificationConstNames
        {
            /// <summary>
            /// 欢迎语
            /// </summary>
            public const string WelcomeToCms = "App.WelcomeToCms";

            public const string SendMessageAsync = "App.SendMessageAsync";
        }

    }
}