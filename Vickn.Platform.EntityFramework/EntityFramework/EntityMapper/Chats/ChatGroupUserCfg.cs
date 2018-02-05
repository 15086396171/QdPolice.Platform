using System.Data.Entity.ModelConfiguration;
using Vickn.Platform.Chats;

namespace Vickn.Platform.EntityFramework.EntityMapper.Chats
{
    public class ChatGroupUserCfg:EntityTypeConfiguration<ChatGroupUser>
    {
        public ChatGroupUserCfg()
        {
            ToTable("ChatGroupUser", PlatformConsts.SchemaName.Chat);

            HasRequired(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        }
    }
}