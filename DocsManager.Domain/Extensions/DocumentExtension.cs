// //DocumentExtension.cs
// // Copyright (c) 2018 07 05All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Domain.DocumentTypes;
using DocsManager.Domain.Entities;

namespace DocsManager.Domain.Extensions
{
    public static class DocumentExtension
    {
        public static Document ConvertToDocumentEntityType(this BaseDocument document)
        {
            return new Document
            {
                Id = document.Id,
                DocumentFile = document.DocumentFile,
                FileName = document.FileName,
                FileType = document.FileType,
                CreatedBy = document.CreatedBy,
                FileSize = document.FileSize,
                Company = document.Company,
                Manager = document.Manager,
                Application = document.Application
            };
        }
    }
}