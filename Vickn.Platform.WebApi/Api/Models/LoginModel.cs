using System.ComponentModel.DataAnnotations;
using Vickn.Platform.HandheldTerminals.Devices.Dtos;

namespace Vickn.Platform.Api.Models
{
    public class LoginModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public DeviceLoginModel DeviceLoginModel { get; set; }
    }

    public class DeviceLoginModel{
        public string Imei { get; set; }

        /// <summary>
        /// app版本
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// 系统版本
        /// </summary>
        public string SystemVersion { get; set; }
    }
}