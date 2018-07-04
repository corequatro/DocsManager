// //DocxDocumetn.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.IO;
using DocsManager.Bll.Dto;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;

namespace DocsManager.Domain.DocumentTypes
{
    public class DocxDocument : BaseDocument
    {
        public override void ProcessDocument()
        {
            var docStream = new MemoryStream();
            file.InputStream.CopyTo(docStream);


            WordprocessingDocument wordprocessingDocument =
                WordprocessingDocument.Open(docStream, true);

            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Company.Text = "fluffysoft";
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Manager = new Manager
            {
                Text = "Billy Gates"
            };
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Save();
            wordprocessingDocument.Close();
            docStream.Position = 0;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                docStream.CopyTo(memoryStream);
                var binData = memoryStream.ToArray();
                var docType = DocFormatHelper.DetermineDocType(binaryReader);
                var createdDocument = await _documentService.CreateDocument(new DocumentDto
                {
                    DocumentFile = binData,
                    FileName = file.FileName,
                    FileType = "Docx",
                    FileSize = file.ContentLength
                });

                docsList.Add(createdDocument);
            }

        }
    }
}