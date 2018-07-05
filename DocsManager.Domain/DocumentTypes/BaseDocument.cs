// //Document.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.IO;
using DocsManager.Domain.Entities;

namespace DocsManager.Domain.DocumentTypes
{
    public abstract class BaseDocument
    {
        public int Id { get; set; }
        public byte[] DocumentFile { get; protected set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }
        public DocumentTypesEnum FileType { get; protected set; }
        public int FileSize { get; set; }
        public MemoryStream FileStream { get; set; }
        public abstract void ProcessDocument();
    }
}