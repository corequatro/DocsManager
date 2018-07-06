namespace DocsManager.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "Application", c => c.String());
            AddColumn("dbo.Document", "Company", c => c.String());
            AddColumn("dbo.Document", "Manager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "Manager");
            DropColumn("dbo.Document", "Company");
            DropColumn("dbo.Document", "Application");
        }
    }
}
