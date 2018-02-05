/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists
* 类 名  称 :     AppWhiteListManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListManager.cs
* 描      述 :     应用白名单管理
* 创建时间 :     2018/2/5 15:11:34
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists
{
	 /// <summary>
    /// 应用白名单管理
    /// </summary>
    public class AppWhiteListManager : IDomainService
    {
        private readonly IRepository<AppWhiteList, long> _appWhiteListRepository;

        /// <summary>
        /// 初始化AppWhiteListManager管理实例
        /// </summary>
        public AppWhiteListManager(IRepository<AppWhiteList, long> appWhiteListRepository)
        {
            _appWhiteListRepository = appWhiteListRepository;
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