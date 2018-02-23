/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites
* 类 名  称 :     PrivatePhoneWhiteManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteManager.cs
* 描      述 :     个人白名单管理
* 创建时间 :     2018/2/23 14:15:10
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PrivatePhoneWhites
{
	 /// <summary>
    /// 个人白名单管理
    /// </summary>
    public class PrivatePhoneWhiteManager : IDomainService
    {
        private readonly IRepository<PrivatePhoneWhite, long> _privatePhoneWhiteRepository;

        /// <summary>
        /// 初始化PrivatePhoneWhiteManager管理实例
        /// </summary>
        public PrivatePhoneWhiteManager(IRepository<PrivatePhoneWhite, long> privatePhoneWhiteRepository)
        {
            _privatePhoneWhiteRepository = privatePhoneWhiteRepository;
        }

        //TODO:编写领域业务代码

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
        }
    }
}