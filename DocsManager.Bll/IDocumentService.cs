// //IDocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Collections.Generic;
using System.Threading.Tasks;
using DocsManager.Bll.Dto;

namespace DocsManager.Bll
{
    public interface IDocumentService
    {
        Task<IList<DocumentDto>> GetAllDocuments(DocumentsFilterDto filterDto);
        Task<DocumentDto> CreateDocument(DocumentDto document);
        Task DeleteDocument(int documentId);
    }
}