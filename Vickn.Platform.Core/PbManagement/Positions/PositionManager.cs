/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions
* 类 名  称 :     PositionManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionManager.cs
* 描      述 :     岗位管理
* 创建时间 :     2018/5/6 14:16:39
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PbManagement.Positions
{
	 /// <summary>
    /// 岗位管理
    /// </summary>
    public class PositionManager : IDomainService
    {
        private readonly IRepository<Position, int> _positionRepository;

        /// <summary>
        /// 初始化PositionManager管理实例
        /// </summary>
        public PositionManager(IRepository<Position, int> positionRepository)
        {
            _positionRepository = positionRepository;
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