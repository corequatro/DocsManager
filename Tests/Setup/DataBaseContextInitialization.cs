// //DataBaseContextInitialization.cs
// // Copyright (c) 2018 07 02All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DocsManager.Bll.Dto;
using DocsManager.Dal;
using DocsManager.Domain.Entities;
using NUnit.Framework;

namespace Tests.Setup
{
    [SetUpFixture]
    public class DataBaseContextInitialization
    {
        private const string TestDataBase = "DocsManager_Test";
        public static string TestDataBaseConnectionString { get; private set; }


        public DataBaseContextInitialization()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DocsManager_Test"].ConnectionString;
            var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
            connectionBuilder.InitialCatalog = TestDataBase;
            TestDataBaseConnectionString = connectionBuilder.ToString();

            DropDatabase();
            CreateDatabase();
        }
        private const string DocHex = "D0-CF-11-E0-A1-B1";
        private const string DocxHex = "50-4B-03-04-14-00";
        private const string RtfHex = "7B-5C-72-74-66-31";

        private static void CreateDatabase()
        {
            using (var context = new DocsManagerDbContext(
                new SqlConnection(TestDataBaseConnectionString)))
            {
                context.Database.Initialize(true);
                context.Database.Create();
                var docBytes = Encoding.Default.GetBytes(DocHex);
                var docXBytes = Encoding.Default.GetBytes(DocxHex);
                var rtfBytes = Encoding.Default.GetBytes(RtfHex);
                context.Documents.Add(new Document()
                {
                    FileSize = 100,
                    CreatedBy = "test",
                    CreatedDate = DateTime.Now,
                    DocumentFile = docBytes,
                    FileType = DocumentTypesEnum.Doc.ToString(),
                    FileName = "hello.doc"
                });
                context.SaveChanges();
            }
        }

        private static void DropDatabase()
        {
            using (var conn = new SqlConnection(TestDataBaseConnectionString))
            {
                try
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText =
                        "USE master; " +
                        $"IF EXISTS(select * from sys.databases where name='{TestDataBase}') " +
                        "BEGIN " +
                        $"ALTER DATABASE {TestDataBase} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                        $"DROP DATABASE {TestDataBase}; " +
                        "End";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //Do nothing cannot drop database.
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}