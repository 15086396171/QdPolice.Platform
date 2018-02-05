using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Vickn.PlatfForm.Utils.Extensions;
using Vickn.Platform.Users;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 消息
    /// </summary>
    public class ChatMessage:CreationAuditedEntity<long>
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
        public User FromUser { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public long? ToUserId { get; set; }


        public virtual User ToUser { get; set; }

        /// <summary>
        /// 接收群组
        /// </summary>
        public long? ToGroupId { get; set; }

        /// <summary>
        /// 接收群组
        /// </summary>
        public virtual ChatGroup ToGroup { get; set; }
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum ChatMessageType
    {
        /// <summary>
        /// 文字
        /// </summary>
        [EnumDescription("文字")]
        Text,
        /// <summary>
        /// 语音
        /// </summary>
        [EnumDescription("语音")]
        Audio,
        /// <summary>
        /// 图片
        /// </summary>
        [EnumDescription("图片")]
        Picture,
    }

    /// <summary>
    /// 消息发送类型
    /// </summary>
    public enum ChatSendType
    {
        /// <summary>
        /// 用户
        /// </summary>
        [EnumDescription("用户")]
        User,

        /// <summary>
        /// 群组
        /// </summary>
        [EnumDescription("群组")]
        Group
    }
}