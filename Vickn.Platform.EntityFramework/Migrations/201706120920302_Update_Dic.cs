namespace Vickn.Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Dic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlatformDataDictionaryItem", "DisplayName", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlatformDataDictionaryItem", "DisplayName");
        }
    }
}
