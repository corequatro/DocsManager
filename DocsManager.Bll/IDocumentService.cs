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
        Task<IList<DocumentDto>> GetAllDocumentsAsync(DocumentsFilterDto filterDto);
        Task CreateDocumentAsync(BaseDocument document);
        Task DeleteDocumentAsync(int documentId);
        Task<DocumentDto> GetDocumentByFileIdAsyncTask(int fileId);
    }
}