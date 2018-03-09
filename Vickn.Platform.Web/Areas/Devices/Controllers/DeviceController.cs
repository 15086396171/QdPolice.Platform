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
using Abp.Runtime.Session;
using Abp.Web.Mvc.Authorization;
using Vickn.PlatfForm.Utils.Extensions;
using Vickn.Platform.HandheldTerminals;
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
        private readonly IForensicsRecordAppService _forensicsRecordAppService;

        public DeviceController(IDeviceAppService deviceAppService, IForensicsRecordAppService forensicsRecordAppService)
        {
            _deviceAppService = deviceAppService;
            _forensicsRecordAppService = forensicsRecordAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(DeviceAppPermissions.Device_CreateDevice, DeviceAppPermissions.Device_EditDevice)]
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

        public async Task<ActionResult> Details(long id)
        {
            var deviceDto = await _deviceAppService.GetByIdAsync(new EntityDto<long>(id));
            return View(deviceDto);
        }

        public async Task<ActionResult> ShowFile(long id)
        {
            ViewBag.id = id;
            return View();
        }

        public async Task<ActionResult> ShowFileDetails(long id)
        {
            var forensicsRecordDto = await _forensicsRecordAppService.GetByIdAsync(new EntityDto<long>(id));

            switch (forensicsRecordDto.ForensicsRecordType)
            {
                case ForensicsRecordType.Audio:
                    return View("Audio", forensicsRecordDto);
                case ForensicsRecordType.Video:
                    return View("Video", forensicsRecordDto);
                case ForensicsRecordType.Picture:
                    return View("Picture", forensicsRecordDto);
            }

            return View();
        }

        public ActionResult VideoCall()
        {
            return View();
        }

      
    }
}