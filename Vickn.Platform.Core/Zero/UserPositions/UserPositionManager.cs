/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions
* 类 名  称 :     UserPositionManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionManager.cs
* 描      述 :     职位信息管理
* 创建时间 :     2018/5/16 9:57:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.Zero.UserPositions
{
	 /// <summary>
    /// 职位信息管理
    /// </summary>
    public class UserPositionManager : IDomainService
    {
        private readonly IRepository<UserPosition, long> _userPositionRepository;

        /// <summary>
        /// 初始化UserPositionManager管理实例
        /// </summary>
        public UserPositionManager(IRepository<UserPosition, long> userPositionRepository)
        {
            _userPositionRepository = userPositionRepository;
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