﻿// //DocDocument.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Domain.Entities;

namespace DocsManager.Domain.DocumentTypes
{
    public class DocDocument : BaseDocument
    {
        public override void ProcessDocument()
        {
            DocumentFile = FileStream.ToArray();
            FileType = DocumentTypesEnum.Doc;
            FileStream.Close();
        }
    }
}