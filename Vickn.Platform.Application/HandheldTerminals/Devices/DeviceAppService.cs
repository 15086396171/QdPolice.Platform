﻿/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices
* 类 名  称 :      DeviceAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceAppService.cs
* 描      述 :     设备服务
* 创建时间 :     2018/2/4 16:27:06
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;

using Vickn.Platform.Dtos;
using Vickn.Platform.HandheldTerminals.Devices.Authorization;
using Vickn.Platform.HandheldTerminals.Devices.Dtos;

namespace Vickn.Platform.HandheldTerminals.Devices
{
	/// <summary>
    /// 设备服务
    /// </summary>
	[AbpAuthorize(DeviceAppPermissions.Device)]
    public class DeviceAppService : PlatformAppServiceBase, IDeviceAppService
    {
	    private readonly IRepository<Device,long> _deviceRepository;
	  	private readonly DeviceManager _deviceManager;

	    /// <summary>
        /// 初始化设备服务实例
        /// </summary>
        public DeviceAppService(IRepository<Device, long> deviceRepository,DeviceManager deviceManager)
        {
            _deviceRepository = deviceRepository;
            _deviceManager = deviceManager;
        }

        #region 设备管理

		/// <summary>
        /// 根据查询条件获取设备分页列表
        /// </summary>
        public async Task<PagedResultDto<DeviceDto>> GetPagedAsync(GetDeviceInput input)
		{
			 var query = _deviceRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var deviceCount = await query.CountAsync();

            var devices = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var deviceDtos = devices.MapTo<List<DeviceDto>>();
            return new PagedResultDto<DeviceDto>(
            deviceCount,
            deviceDtos
            );
		}

		/// <summary>
        /// 通过指定id获取设备Dto信息
        /// </summary>
        public async Task<DeviceDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _deviceRepository.GetAsync(input.Id);
            return entity.MapTo<DeviceDto>();
		}

        /// <summary>
        /// 通过Id获取设备信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<DeviceForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			DeviceEditDto deviceEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _deviceRepository.GetAsync(input.Id.Value);
                deviceEditDto = entity.MapTo<DeviceEditDto>();
            }
            else
            {
                deviceEditDto = new DeviceEditDto();
            }
            return new DeviceForEdit { DeviceEditDto = deviceEditDto };
		}

        /// <summary>
        /// 新增或更改设备
        /// </summary>
		[AbpAuthorize(DeviceAppPermissions.Device_CreateDevice,DeviceAppPermissions.Device_EditDevice)]
        public async Task CreateOrUpdateAsync(DeviceForEdit input)
		{
			 if (input.DeviceEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增设备
        /// </summary>
		[AbpAuthorize(DeviceAppPermissions.Device_CreateDevice)]
        public async Task<DeviceForEdit> CreateAsync(DeviceForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.DeviceEditDto.MapTo<Device>();

            entity = await _deviceRepository.InsertAsync(entity);
            return new DeviceForEdit { DeviceEditDto = entity.MapTo<DeviceEditDto>() };
		}

        /// <summary>
        /// 修改设备
        /// </summary>
		[AbpAuthorize(DeviceAppPermissions.Device_EditDevice)]
        public async Task UpdateAsync(DeviceForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _deviceRepository.GetAsync(input.DeviceEditDto.Id.Value);
            input.DeviceEditDto.MapTo(entity);

            await _deviceRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除设备
        /// </summary>
		[AbpAuthorize(DeviceAppPermissions.Device_DeleteDevice)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _deviceRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除设备
        /// </summary>
		[AbpAuthorize(DeviceAppPermissions.Device_DeleteDevice)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _deviceRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查设备输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(DeviceForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
