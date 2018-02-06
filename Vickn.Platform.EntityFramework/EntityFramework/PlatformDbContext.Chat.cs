using System.Data.Entity;
using Vickn.Platform.Chats;
using Vickn.Platform.EntityFramework.EntityMapper.Chats;

namespace Vickn.Platform.EntityFramework
{
    public partial class PlatformDbContext
    {
        public virtual IDbSet<ChatGroup> ChatGroups { get; set; }

        public virtual IDbSet<ChatGroupUser> ChatGroupUsers { get; set; }

        public virtual IDbSet<ChatHistory> ChatHistories { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        private void ChatConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChatGroupCfg());
            modelBuilder.Configurations.Add(new ChatGroupUserCfg());
            modelBuilder.Configurations.Add(new ChatMessageCfg());
            modelBuilder.Configurations.Add(new ChatHistoryCfg());
        }
    }
}