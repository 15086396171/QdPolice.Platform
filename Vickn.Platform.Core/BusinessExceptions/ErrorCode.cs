using Vickn.PlatfForm.Utils.Extensions;

namespace Vickn.Platform.BusinessExceptions
{
    /// <summary>
    /// 错误码定义
    /// </summary>
    public enum ErrorCode:int
    {
        [EnumDescription("输入错误消息")]
        Normal=1,
        #region 注册模块 10000
        #endregion
    }
}