namespace DocsManager.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTypeAsEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Document", "FileType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Document", "FileType", c => c.String());
        }
    }
}
