// //DocumentServiceTest.cs
// // Copyright (c) 2018 07 02All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com



using System.Threading.Tasks;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManager.IDal;
using DocsManagerWebApp.App_Start;
using DocsManagerWebApp.Controllers;
using Ninject;
using NUnit.Framework;

namespace Tests.Tests
{
    [TestFixture]
    public class DocumentServiceTest : ServiceTestBase
    {
        private IDocumentService _docService;

        [SetUp]
        public void DocumentServiceSetup()
        {
            _docService = _kernel.Get<IDocumentService>();
        }

        [Test]
        public async Task CreateDocument_ByDocumentDto_CorrectRecordInDbCreated()
        {
            var document = await _docService.CreateDocument(new DocumentDto()
            {
                FileName = "file",
                FileType = "someFile",
                FileSize = 222
            });
            var documents = await _docService.GetAllDocuments(new DocumentsFilterDto());
            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDown()
        {
            Context.Documents.RemoveRange(Context.Documents);
            Context.SaveChanges();
        }
    }
}
