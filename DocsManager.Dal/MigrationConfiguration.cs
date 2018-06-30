// //MigrationConfiguration.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Data.Entity.Migrations;

namespace DocsManager.Dal
{
    public class MigrationConfiguration : DbMigrationsConfiguration<DocsManagerDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
        }
    }
}