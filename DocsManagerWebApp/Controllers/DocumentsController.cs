using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManagerWebApp.Models.Documents;
using Newtonsoft.Json;

namespace DocsManagerWebApp.Controllers
{
    public class DocumentsController : BaseController
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;

        }

        [HttpGet]
        public async Task<ActionResult> GetDocumentsList(DocumentsFilterViewModel viewModel)
        {
            var items = await _documentService.GetAllDocuments((DocumentsFilterDto)viewModel);
            return GetJson(items);
        }
        
        [HttpPost]
        public async Task<ActionResult> UploadDocument(HttpPostedFileBase file)
        {
            using (BinaryReader b = new BinaryReader(file.InputStream))
            {
                byte[] binData = b.ReadBytes(file.ContentLength);
                var createdDocument = await _documentService.CreateDocument(new DocumentDto
                {
                    DocumentFile = binData,
                    FileName = file.FileName,
                    FileType = file.ContentType
                });
                return GetJson(createdDocument);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFile(int documentId)
        {
            return GetJson(new
            {
                Success = true,
                UploadedFileName = ""
            });
        }


    }
}