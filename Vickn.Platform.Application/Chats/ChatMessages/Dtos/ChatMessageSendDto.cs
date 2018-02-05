using Abp.AutoMapper;
using Vickn.Platform.Users;

namespace Vickn.Platform.Chats.ChatMessages
{
    /// <summary>
    /// 消息接收对象
    /// </summary>
    [AutoMap(typeof(ChatMessage))]
    public class ChatMessageSendDto
    {
        /// <summary>
        /// 正文
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Tickets { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public ChatMessageType ChatMessageType { get; set; }

        /// <summary>
        /// 消息发送类型
        /// </summary>
        public ChatSendType ChatSendType { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public long? ToUserId { get; set; }

        /// <summary>
        /// 接收群组
        /// </summary>
        public long? ToGroupId { get; set; }
    }
}