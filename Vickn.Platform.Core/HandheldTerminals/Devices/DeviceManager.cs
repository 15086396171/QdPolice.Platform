/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices
* 类 名  称 :     DeviceManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceManager.cs
* 描      述 :     设备管理
* 创建时间 :     2018/2/4 16:27:02
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.HandheldTerminals.Devices
{
	 /// <summary>
    /// 设备管理
    /// </summary>
    public class DeviceManager : IDomainService
    {
        private readonly IRepository<Device, long> _deviceRepository;

        /// <summary>
        /// 初始化DeviceManager管理实例
        /// </summary>
        public DeviceManager(IRepository<Device, long> deviceRepository)
        {
            _deviceRepository = deviceRepository;
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