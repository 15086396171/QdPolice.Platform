/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs
* 类 名  称 :     PositionPbManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbManager.cs
* 描      述 :     单个岗位下排班时间管理
* 创建时间 :     2018/5/7 13:34:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PbManagement.PositionPbs
{
	 /// <summary>
    /// 单个岗位下排班时间管理
    /// </summary>
    public class PositionPbManager : IDomainService
    {
        private readonly IRepository<PositionPb, int> _positionPbRepository;

        /// <summary>
        /// 初始化PositionPbManager管理实例
        /// </summary>
        public PositionPbManager(IRepository<PositionPb, int> positionPbRepository)
        {
            _positionPbRepository = positionPbRepository;
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