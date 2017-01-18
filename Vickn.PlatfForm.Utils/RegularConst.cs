namespace Vickn.PlatfForm.Utils
{
    public static class RegularConst
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        public const string EmailRegularExpression = @"\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}";

        public const string EmailErrorMsg = "电子邮件 格式不正确";

        /// <summary>
        /// 电话号码
        /// </summary>
        public const string PhoneRegularExpression =
            @"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";

        public const string PhoneErrorMsg = "电话号码 格式不正确";
    }
}