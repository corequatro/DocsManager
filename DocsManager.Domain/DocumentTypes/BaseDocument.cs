// //Document.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.IO;
using System.Threading;

namespace DocsManager.Domain.DocumentTypes
{
    public abstract class BaseDocument
    {
        public int Id { get; set; }
        public byte[] DocumentFile { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public MemoryStream FileStream { get; set; }
        public abstract void ProcessDocument();

    }
}