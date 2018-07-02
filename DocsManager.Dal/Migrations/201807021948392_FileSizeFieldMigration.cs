namespace DocsManager.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileSizeFieldMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "FileSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "FileSize");
        }
    }
}
