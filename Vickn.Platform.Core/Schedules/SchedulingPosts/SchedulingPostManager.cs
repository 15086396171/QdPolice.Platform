/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts
* 类 名  称 :     SchedulingPostManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostManager.cs
* 描      述 :     岗位设置管理
* 创建时间 :     2018/5/3 15:40:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.Schedules.SchedulingPosts
{
	 /// <summary>
    /// 岗位设置管理
    /// </summary>
    public class SchedulingPostManager : IDomainService
    {
        private readonly IRepository<SchedulingPost, long> _schedulingPostRepository;

        /// <summary>
        /// 初始化SchedulingPostManager管理实例
        /// </summary>
        public SchedulingPostManager(IRepository<SchedulingPost, long> schedulingPostRepository)
        {
            _schedulingPostRepository = schedulingPostRepository;
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