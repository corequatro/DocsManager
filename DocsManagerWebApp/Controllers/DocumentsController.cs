// //DocumentsController.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocsManager.Bll;
using DocsManager.Bll.Dto;
using DocsManagerWebApp.Factories;
using DocsManagerWebApp.Models.Documents;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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
              
                var document = DocumentFactory.DetermineDocType(file);
                var documentCreated = await _documentService.CreateDocument(document);



               
            }
            return GetJson(docsList);
        }



        [HttpGet]
        public async Task<ActionResult> DownloadDocument(int fileId)
        {
            var document = await _documentService.GetDocumentByFileId(fileId);
            var cd = new ContentDisposition
            {
                FileName = document.FileName,
                Inline = false
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            Enum.TryParse(document.FileType, out DocumentTypesEnum myStatus);
            return File(document.DocumentFile, DocFormatHelper.GetMimeTypeByFormatType(myStatus));
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