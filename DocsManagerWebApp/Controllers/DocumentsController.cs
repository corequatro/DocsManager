using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManager.Bll.Utils;
using DocsManagerWebApp.Models.Documents;
using Microsoft.ApplicationInsights.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        public async Task<ActionResult> UploadMultiplyDocs(IEnumerable<HttpPostedFileBase> files)
        {
            var docsList = new List<DocumentDto>();
            
            foreach (var file in files)
            {
                using (BinaryReader binaryReader = new BinaryReader(file.InputStream))
                {
                    var docType = DocFormatType.DetermineDocType(binaryReader);
                    ////Read fib base
                    //binaryReader.BaseStream.Position = 0x200;
                    //byte[] fibBase = binaryReader.ReadBytes(0x652);
                    
                    byte[] binData = binaryReader.ReadBytes(file.ContentLength);
                    var createdDocument = await _documentService.CreateDocument(new DocumentDto
                    {
                        DocumentFile = binData,
                        FileName = file.FileName,
                        FileType = docType.ToString()
                    });

                    docsList.Add(createdDocument);
                }
            }
            return GetJson(docsList);
        }


        [HttpPost]
        public async Task<ActionResult> UploadDocument(HttpPostedFileBase file)
        {
            const uint summaryInfoAddress = 0x05;

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