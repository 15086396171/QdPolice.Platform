/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices
* 类 名  称 :      DeviceController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceController.cs
* 描      述 :     设备控制器
* 创建时间 :     2018/2/5 9:46:27
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.HandheldTerminals.Devices;
using Vickn.Platform.HandheldTerminals.Devices.Authorization;
using Vickn.Platform.HandheldTerminals.Devices.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.Devices.Controllers
{
	[AbpMvcAuthorize(DeviceAppPermissions.Device)]
    public class DeviceController : PlatformControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;

        public DeviceController(IDeviceAppService deviceAppService)
        {
            _deviceAppService = deviceAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(DeviceAppPermissions.Device_CreateDevice,DeviceAppPermissions.Device_EditDevice)]
        public async Task<ActionResult> Create(long? id)
        {
			var deviceDto = await _deviceAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(deviceDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(DeviceForEdit deviceDto)
        {
            if (!CheckModelState(await _deviceAppService.CheckErrorAsync(deviceDto)))
            {
			   return View(deviceDto);
			 }
            await _deviceAppService.CreateOrUpdateAsync(deviceDto);
            return RedirectToAction("Index");
        }

    }
}