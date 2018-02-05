namespace Vickn.Platform.HandheldTerminals.Devices
{
    /// <summary>
    /// 设备登录结果
    /// </summary>
    public class DeviceLoginResult
    {
        public DeviceLoginEnum DeviceLogin { get; set; }

        public Device Device { get; set; }
    }

    public enum DeviceLoginEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success,

        /// <summary>
        /// 设备已绑定其他账号
        /// </summary>
        NotMe
    }
}