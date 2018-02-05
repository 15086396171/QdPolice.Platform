using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.Chats;

namespace Vickn.Platform.EntityFramework.EntityMapper.Chats
{
    public class ChatGroupCfg:EntityTypeConfiguration<ChatGroup>
    {
        public ChatGroupCfg()
        {
            ToTable("ChatGroup", PlatformConsts.SchemaName.Chat);

            HasMany(p => p.ChatGroupUsers).WithRequired().HasForeignKey(p => p.ChatGroupId);
        }
    }
}