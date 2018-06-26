// //DocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

using System.Collections.Generic;
using DocsManager.Domain.Entities;
using DocsManager.IBll;
using DocsManager.IDal;

namespace DocsManager.Bll
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> _documentRepository;

        public DocumentService(IRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public IList<string> GetAllDocuments()
        {
            return new List<string>(){"hello"};
        }
    }
}