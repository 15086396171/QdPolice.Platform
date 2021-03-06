﻿/*
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
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Extensions;
using Vickn.Platform.Users;

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

        public async Task<DeviceLoginResult> DeviceLoginAsync(string imei, string appversion, string systemVersion, string status, User user)
        {
            var device = await _deviceRepository.FirstOrDefaultAsync(p => p.Imei == imei);
            status = status.IsNullOrEmpty() ? "安全模式" : status;
            if (device == null)
            {
                device = new Device()
                {
                    Imei = imei,
                    User = user,
                    AppVersion = appversion,
                    SystemVersion = systemVersion,
                    No = await GetNo(),
                    Status = status,
                };
                device.Id = await _deviceRepository.InsertAndGetIdAsync(device);
                return new DeviceLoginResult()
                {
                    Device = device,
                    DeviceLogin = DeviceLoginEnum.Success,
                };
            }
            if (device.CreatorUserId != user.Id)
            {
                return new DeviceLoginResult()
                {
                    DeviceLogin = DeviceLoginEnum.NotMe,
                };
            }

            device.Status = status;
            device.AppVersion = appversion;
            device.SystemVersion = systemVersion;
            return new DeviceLoginResult()
            {
                Device = device,
                DeviceLogin = DeviceLoginEnum.Success,
            };
        }

        private async Task<string> GetNo()
        {
            var device = await _deviceRepository.GetAll().OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (device != null)
            {
                return (int.Parse(device.No) + 1).ToString("D5");
            }
            return "00001";
        }
    }
}