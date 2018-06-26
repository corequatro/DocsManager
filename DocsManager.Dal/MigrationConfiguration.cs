// //MigrationConfiguration.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

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