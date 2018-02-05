using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 聊天记录
    /// </summary>
    public class ChatHistory:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 消息
        /// </summary>
        public virtual ChatMessage ChatMessage { get; set; }

        /// <summary>
        /// 消息Id
        /// </summary>
        public long ChatMessageId { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public long ToUserId { get; set; }
    }
}