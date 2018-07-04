// //IDocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Collections.Generic;
using System.Threading.Tasks;
using DocsManager.Bll.Dto;
using DocsManager.Domain.DocumentTypes;

namespace DocsManager.Bll
{
    public interface IDocumentService
    {
        Task<IList<DocumentDto>> GetAllDocuments(DocumentsFilterDto filterDto);
        Task<DocumentDto> CreateDocument(DocumentDto document);
        Task<BaseDocument> CreateDocument(BaseDocument document);
        Task DeleteDocument(int documentId);
        Task<DocumentDto> GetDocumentByFileId(int fileId);
    }
}