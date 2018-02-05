using System.Data.Entity;
using Vickn.Platform.Chats;
using Vickn.Platform.EntityFramework.EntityMapper.Chats;

namespace Vickn.Platform.EntityFramework
{
    public partial class PlatformDbContext
    {
        public IDbSet<ChatGroup> ChatGroups { get; set; }

        public IDbSet<ChatGroupUser> ChatGroupUsers { get; set; }

        public IDbSet<ChatHistory> ChatHistories { get; set; }

        public IDbSet<ChatMessage> ChatMessages { get; set; }

        private void ChatConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChatGroupCfg());
            modelBuilder.Configurations.Add(new ChatGroupUserCfg());
            modelBuilder.Configurations.Add(new ChatMessageCfg());
            modelBuilder.Configurations.Add(new ChatHistoryCfg());
        }
    }
}