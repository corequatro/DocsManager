namespace DocsManager.Dal
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Document", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Document", "UpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
