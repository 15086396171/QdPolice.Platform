using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.Chats;

namespace Vickn.Platform.EntityFramework.EntityMapper.Chats
{
    public class ChatMessageCfg:EntityTypeConfiguration<ChatMessage>
    {
        public ChatMessageCfg()
        {
            ToTable("ChatMessage", PlatformConsts.SchemaName.Chat);

            Property(p => p.Message).HasMaxLength(1024);

            HasRequired(p => p.FromUser).WithMany().HasForeignKey(p => p.CreatorUserId);
            HasOptional(p => p.ToUser).WithMany().HasForeignKey(p => p.ToUserId);
            HasOptional(p => p.ToGroup).WithMany().HasForeignKey(p => p.ToGroupId);
        }
    }
}