// //DocsManagerDbContext.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DocsManager.Domain.Entities;

namespace DocsManager.Dal
{
    public class DocsManagerDbContext : DbContext
    {
        public DocsManagerDbContext() : this("DocsManager")
        {
        }

        public DocsManagerDbContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DocsManagerDbContext, MigrationConfiguration>());
        }


        public DocsManagerDbContext(DbConnection connection) : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DocsManagerDbContext, MigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove Pluralizing Table Name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(DocsManagerDbContext).Assembly);
        }

        public DbSet<Document> Documents { get; set; }
    }
}