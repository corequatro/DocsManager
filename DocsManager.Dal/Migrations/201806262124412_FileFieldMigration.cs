namespace DocsManager.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileFieldMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "DocumentFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "DocumentFile");
        }
    }
}
