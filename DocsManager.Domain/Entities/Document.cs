// //Document.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

using System;
using DocsManager.Domain.BaseEntities;

namespace DocsManager.Domain.Entities 
{
    public class Document : IIdEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}