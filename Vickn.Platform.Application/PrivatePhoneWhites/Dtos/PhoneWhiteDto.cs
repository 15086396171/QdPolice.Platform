namespace Vickn.Platform.PrivatePhoneWhites.Dtos
{
    /// <summary>
    /// 通话白名单
    /// </summary>
    public class PhoneWhiteDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneWhiteType PhoneWhiteType { get; set; }
    }

    public enum PhoneWhiteType
    {
        /// <summary>
        /// 个人白名单
        /// </summary>
        Private,

        /// <summary>
        /// 公共白名单
        /// </summary>
        Public,
    }
}