// //DocumentsController.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManagerWebApp.Factories;
using DocsManagerWebApp.Models.Documents;

namespace DocsManagerWebApp.Controllers
{
    public class DocumentsController : BaseController
    {
        private readonly IDocumentService _documentService;
        private readonly DocumentFactory _documentFactory;
        public DocumentsController(IDocumentService documentService, DocumentFactory documentFactory)
        {
            _documentService = documentService;
            _documentFactory = new DocumentFactory();
        }

        [HttpGet]
        public async Task<ActionResult> GetDocumentsList(DocumentsFilterViewModel viewModel)
        {
            var items = await _documentService.GetAllDocumentsAsync((DocumentsFilterDto)viewModel);
            return GetJson(items);
        }

        [HttpPost]
        public async Task<ActionResult> UploadMultiplyDocs(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                var document = _documentFactory.BuildDocumentForProcessing(file);
                document.ProcessDocument();
                document.FileName = file.FileName;
                document.FileSize = file.ContentLength;
                await _documentService.CreateDocumentAsync(document);
            }

            return ReturnSuccess();
        }

        [HttpGet]
        public async Task<ActionResult> DownloadDocument(int fileId)
        {
            var document = await _documentService.GetDocumentByFileIdAsyncTask(fileId);
            var cd = new ContentDisposition
            {
                FileName = document.FileName,
                Inline = false
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(document.DocumentFile, _documentFactory.GetMimeTypeByFormatType(document.FileType));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteDocument(int documentId)
        {
            await _documentService.DeleteDocumentAsync(documentId);
            return ReturnSuccess();
        }
    }
}