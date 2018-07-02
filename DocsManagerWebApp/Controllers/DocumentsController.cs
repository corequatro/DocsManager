using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManager.Bll.Utils;
using DocsManagerWebApp.Models.Documents;

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
        public async Task<ActionResult> DeleteDocument(int documentId)
        {
            await _documentService.DeleteDocument(documentId);
            return GetJson(new
            {
                Success = true
            });
        }


    }
}