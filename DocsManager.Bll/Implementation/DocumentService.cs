// //DocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DocsManager.Bll.Dto;
using DocsManager.Domain.DocumentTypes;
using DocsManager.Domain.Entities;
using DocsManager.Domain.Extensions;
using DocsManager.Domain.Verification;
using DocsManager.IDal;

namespace DocsManager.Bll.Implementation
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> _documentRepository;

        public DocumentService(IRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IList<DocumentDto>> GetDocumentsAsync(DocumentsFilterDto filterDto)
        {
            return await _documentRepository.GetItemsQuery().Select(i => new DocumentDto
            {
                Id = i.Id,
                FileName = i.FileName,
                FileType = i.FileType,
                FileSize = i.FileSize,
                Company = i.Company,
                Manager = i.Manager,
                Application = i.Application,
                CreatedDate = i.CreatedDate,
            }).OrderBy(i => i.Id)
                .Skip(filterDto.Offset)
                .Take(filterDto.CountOnPage).ToListAsync();
        }

        public async Task<int> GetDocumentsCountAsync(DocumentsFilterDto filterDto)
        {
            return await _documentRepository.GetItemsQuery().CountAsync();
        }

        public async Task CreateDocumentAsync(BaseDocument document)
        {
            BusinessLogic.RequiresThat(document.FileSize <= 2e+8, "file size must be less than 200mb");
            await _documentRepository.AddAsync(document.ConvertToDocumentEntityType());
        }

        public async Task DeleteDocumentAsync(int documentId)
        {
            await _documentRepository.RemoveAsync(documentId);
        }

        public async Task<DocumentDto> GetDocumentByFileIdAsyncTask(int fileId)
        {
            return (DocumentDto)await _documentRepository.GetItemsQuery().FirstOrDefaultAsync(i => i.Id.Equals(fileId));
        }
    }
}