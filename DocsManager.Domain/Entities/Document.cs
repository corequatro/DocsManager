// //Document.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using DocsManager.Domain.BaseEntities;

namespace DocsManager.Domain.Entities
{
    public class Document : IIdEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public byte[] DocumentFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}