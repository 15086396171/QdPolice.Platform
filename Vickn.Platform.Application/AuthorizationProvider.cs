﻿using Abp.Configuration.Startup;
using Vickn.Platform.Authorization.Roles.Authorization;
using Vickn.Platform.Users.Authorization;

namespace Vickn.Platform
{
    /// <summary>
    /// 提供系统权限注入
    /// </summary>
    public class AuthorizationProvider
    {
        /// <summary>
        /// 添加所有系统权限
        /// </summary>
        /// <param name="Configuration"></param>
        public void AddAuthorizationProviders(IAbpStartupConfiguration Configuration)
        {
            Configuration.Authorization.Providers.Add<UserAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<RoleAppAuthorizationProvider>();

        }
    }
}