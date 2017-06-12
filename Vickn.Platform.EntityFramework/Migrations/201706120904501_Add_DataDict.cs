namespace Vickn.Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DataDict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlatformDataDictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 16),
                        DisplayName = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlatformDataDictionaryItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 32),
                        DataDictionaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatformDataDictionary", t => t.DataDictionaryId, cascadeDelete: true)
                .Index(t => t.DataDictionaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatformDataDictionaryItem", "DataDictionaryId", "dbo.PlatformDataDictionary");
            DropIndex("dbo.PlatformDataDictionaryItem", new[] { "DataDictionaryId" });
            DropTable("dbo.PlatformDataDictionaryItem");
            DropTable("dbo.PlatformDataDictionary");
        }
    }
}
