namespace Vickn.Platform.Dtos
{
    /// <summary>
    /// 表示自定义验证错误返回类
    /// </summary>
    public class CustomerModelStateValidationDto
    {
        public CustomerModelStateValidationDto()
        {

        }
        public CustomerModelStateValidationDto(bool hasModelError, string key, string errorMsg)
        {
            HasModelError = hasModelError;
            Key = key;
            ErrorMessage = ErrorMessage;
        }
        /// <summary>
        /// 是否验证错误
        /// </summary>
        public bool HasModelError { get; set; }

        /// <summary>
        /// 错误字段名，可为string.empty
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///   错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}