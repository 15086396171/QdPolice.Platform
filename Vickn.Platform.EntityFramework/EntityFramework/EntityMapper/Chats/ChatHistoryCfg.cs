using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.Chats;

namespace Vickn.Platform.EntityFramework.EntityMapper.Chats
{
    public class ChatHistoryCfg:EntityTypeConfiguration<ChatHistory>
    {
        public ChatHistoryCfg()
        {
            ToTable("ChatHistory", PlatformConsts.SchemaName.Chat);

            HasRequired(p => p.ChatMessage).WithMany().HasForeignKey(p => p.ChatMessageId);
        }
    }
}