namespace Vickn.Platform.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Chat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chat.ChatGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChatGroup_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Chat.ChatGroupUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChatGroupId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatformUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Chat.ChatGroup", t => t.ChatGroupId, cascadeDelete: true)
                .Index(t => t.ChatGroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Chat.ChatHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChatMessageId = c.Long(nullable: false),
                        ToUserId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Chat.ChatMessage", t => t.ChatMessageId, cascadeDelete: true)
                .Index(t => t.ChatMessageId);
            
            CreateTable(
                "Chat.ChatMessage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Message = c.String(maxLength: 1024),
                        Tickets = c.Long(nullable: false),
                        ChatMessageType = c.Int(nullable: false),
                        ChatSendType = c.Int(nullable: false),
                        ToUserId = c.Long(),
                        ToGroupId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatformUsers", t => t.CreatorUserId, cascadeDelete: true)
                .ForeignKey("Chat.ChatGroup", t => t.ToGroupId)
                .ForeignKey("dbo.PlatformUsers", t => t.ToUserId)
                .Index(t => t.ToUserId)
                .Index(t => t.ToGroupId)
                .Index(t => t.CreatorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Chat.ChatHistory", "ChatMessageId", "Chat.ChatMessage");
            DropForeignKey("Chat.ChatMessage", "ToUserId", "dbo.PlatformUsers");
            DropForeignKey("Chat.ChatMessage", "ToGroupId", "Chat.ChatGroup");
            DropForeignKey("Chat.ChatMessage", "CreatorUserId", "dbo.PlatformUsers");
            DropForeignKey("Chat.ChatGroupUser", "ChatGroupId", "Chat.ChatGroup");
            DropForeignKey("Chat.ChatGroupUser", "UserId", "dbo.PlatformUsers");
            DropIndex("Chat.ChatMessage", new[] { "CreatorUserId" });
            DropIndex("Chat.ChatMessage", new[] { "ToGroupId" });
            DropIndex("Chat.ChatMessage", new[] { "ToUserId" });
            DropIndex("Chat.ChatHistory", new[] { "ChatMessageId" });
            DropIndex("Chat.ChatGroupUser", new[] { "UserId" });
            DropIndex("Chat.ChatGroupUser", new[] { "ChatGroupId" });
            DropTable("Chat.ChatMessage");
            DropTable("Chat.ChatHistory");
            DropTable("Chat.ChatGroupUser");
            DropTable("Chat.ChatGroup",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChatGroup_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
