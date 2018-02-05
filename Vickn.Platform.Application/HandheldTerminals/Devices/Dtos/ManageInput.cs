using Abp.Application.Services.Dto;

namespace Vickn.Platform.HandheldTerminals.Devices.Dtos
{
    /// <summary>
    /// 设备管理
    /// </summary>
    public class ManageInput:EntityDto<long>
    {
        /// <summary>
        /// 操作
        /// </summary>
        public string Operation { get; set; }
    }
}