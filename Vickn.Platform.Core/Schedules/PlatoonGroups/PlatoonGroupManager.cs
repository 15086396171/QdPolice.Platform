/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups
* 类 名  称 :     PlatoonGroupManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupManager.cs
* 描      述 :     排班组管理
* 创建时间 :     2018/5/4 15:19:48
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.Schedules.PlatoonGroups
{
	 /// <summary>
    /// 排班组管理
    /// </summary>
    public class PlatoonGroupManager : IDomainService
    {
        private readonly IRepository<PlatoonGroup, long> _platoonGroupRepository;

        /// <summary>
        /// 初始化PlatoonGroupManager管理实例
        /// </summary>
        public PlatoonGroupManager(IRepository<PlatoonGroup, long> platoonGroupRepository)
        {
            _platoonGroupRepository = platoonGroupRepository;
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