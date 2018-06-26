// //IDocumentService.cs
// // Copyright (c) 2018 06 27All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

using System.Collections.Generic;

namespace DocsManager.IBll
{
    public interface IDocumentService
    {
        IList<string> GetAllDocuments();
    }
}