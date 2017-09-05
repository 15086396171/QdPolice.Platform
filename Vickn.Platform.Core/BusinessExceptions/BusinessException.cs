using System;
using System.Runtime.Serialization;
using Abp;
using Abp.Logging;
using Abp.UI;
using Vickn.PlatfForm.Utils.Extensions;

namespace Vickn.Platform.BusinessExceptions
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException : UserFriendlyException
    {
        //
        // 摘要:
        //     Constructor.
        public BusinessException() : base() { }
        //
        // 摘要:
        //     Constructor.
        //
        // 参数:
        //   message:
        //     Exception message
        public BusinessException(string message) : base(message) { }
        //
        // 摘要:
        //     Constructor for serializing.
        public BusinessException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) { }
        //
        // 摘要:
        //     Constructor.
        //
        // 参数:
        //   message:
        //     Exception message
        //
        //   severity:
        //     Exception severity
        public BusinessException(string message, LogSeverity severity) : base(message, severity) { }

        public BusinessException(ErrorCode code) : base((int)code, code.GetDescription()) { }

        //
        // 摘要:
        //     Constructor.
        //
        // 参数:
        //   code:
        //     Error code
        //
        //   message:
        //     Exception message
        public BusinessException(ErrorCode code, string message) : base((int)code, message) { }

        public BusinessException(ErrorCode code, string message, string details) : base((int)code, message, details) { }
        //
        // 摘要:
        //     Constructor.
        //
        // 参数:
        //   message:
        //     Exception message
        //
        //   details:
        //     Additional information about the exception
        //
        //   innerException:
        //     Inner exception
        public BusinessException(string message, string details, Exception innerException) : base(message, details, innerException) { }
    }
}