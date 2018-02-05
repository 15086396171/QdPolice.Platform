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
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
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

        public async Task<DeviceLoginResult> DeviceLoginAsync(string imei,string appversion,string systemVersion, User user)
        {
            var device = await _deviceRepository.FirstOrDefaultAsync(p => p.Imei == imei);
            if (device == null)
            {
                device = new Device()
                {
                    Imei = imei,
                    User = user,
                    AppVersion = appversion,
                    SystemVersion = systemVersion,
                    No = await GetNo()
                };
                await _deviceRepository.InsertAsync(device);
                return DeviceLoginResult.Success;
            }
            if (device.CreatorUserId != user.Id)
            {
                return DeviceLoginResult.NotMe;
            }
            return DeviceLoginResult.Success;
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