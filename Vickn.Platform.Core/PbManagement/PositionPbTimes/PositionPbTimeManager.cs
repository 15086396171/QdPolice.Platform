/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes
* 类 名  称 :     PositionPbTimeManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeManager.cs
* 描      述 :     当天上下班时间管理
* 创建时间 :     2018/5/8 14:06:14
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
	 /// <summary>
    /// 当天上下班时间管理
    /// </summary>
    public class PositionPbTimeManager : IDomainService
    {
        private readonly IRepository<PositionPbTime, int> _positionPbTimeRepository;

        /// <summary>
        /// 初始化PositionPbTimeManager管理实例
        /// </summary>
        public PositionPbTimeManager(IRepository<PositionPbTime, int> positionPbTimeRepository)
        {
            _positionPbTimeRepository = positionPbTimeRepository;
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