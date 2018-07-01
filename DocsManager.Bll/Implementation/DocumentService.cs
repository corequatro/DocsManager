// //DocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DocsManager.Bll.Dto;
using DocsManager.Domain.Entities;
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


        public async Task<IList<DocumentDto>> GetAllDocuments(DocumentsFilterDto filterDto)
        {
            return await _documentRepository.GetItemsQuery().Select(i => new DocumentDto
            {
                Id = i.Id,
                CreatedDate = i.CreatedDate,
                FileName = i.FileName,
                FileType = i.FileType
            }).ToListAsync();
        }

        public async Task<DocumentDto> CreateDocument(DocumentDto document)
        {
            BusinessLogic.RequiresThat(document.FileSize <= 2e+8, "file size is too big");
            return (DocumentDto)await _documentRepository.AddAsync((Document)document);
        }
 }
}