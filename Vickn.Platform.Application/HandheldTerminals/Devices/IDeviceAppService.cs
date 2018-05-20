/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices
* 类 名  称 :      IDeviceAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IDeviceAppService.cs
* 描      述 :     设备服务接口
* 创建时间 :     2018/2/4 16:27:06
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.HandheldTerminals.Devices.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.HandheldTerminals.Devices
{
     /// <summary>
    /// 设备服务接口
    /// </summary>
    public interface IDeviceAppService : IApplicationService
    {
        #region 设备管理

		/// <summary>
        /// 根据查询条件获取设备分页列表
        /// </summary>
        Task<PagedResultDto<DeviceDto>> GetPagedAsync(GetDeviceInput input);

		 /// <summary>
        /// 通过指定id获取设备Dto信息
        /// </summary>
        Task<DeviceDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 修改模式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateStatusAsymc(DeviceStatusEditInput input);

        /// <summary>
        /// 修改地理位置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task GeographicalPosition(DeviceGeographicalPositionEditInput input);

        

        /// <summary>
        /// 通过Id获取设备信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<DeviceForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改设备
        /// </summary>
        Task CreateOrUpdateAsync(DeviceForEdit input);

        /// <summary>
        /// 新增设备
        /// </summary>
        Task<DeviceForEdit> CreateAsync(DeviceForEdit input);

        /// <summary>
        /// 修改设备
        /// </summary>
        Task UpdateAsync(DeviceForEdit input);

        /// <summary>
        /// 删除设备
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除设备
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 管理设备
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ManageAsync(ManageInput input);

            /// <summary>
        /// 自定义检查设备输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(DeviceForEdit input);

        #endregion

    }
}
