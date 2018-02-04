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
    }
}