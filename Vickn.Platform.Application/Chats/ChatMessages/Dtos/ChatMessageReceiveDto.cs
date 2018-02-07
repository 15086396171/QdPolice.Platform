using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Vickn.Platform.Chats.ChatGroups.Dtos;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Dtos;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Chats.ChatMessages
{
    /// <summary>
    /// 消息接收对象
    /// </summary>
    [AutoMapFrom(typeof(ChatMessage))]
    public class ChatMessageReceiveDto : CreationAuditedEntity<long>
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
        /// 发送人
        /// </summary>
        public UserSimpleDto FromUser { get; set; }

        public UserSimpleDto ToUser { get; set; }

        /// <summary>
        /// 接收群组
        /// </summary>
        public long? ToGroupId { get; set; }

        public long? ToUserId { get; set; }

        /// <summary>
        /// 接收群组
        /// </summary>
        public ChatMessageGroupDto ToGroup { get; set; }
    }
}