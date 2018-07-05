// //RtfDocument.cs
// // Copyright (c) 2018 07 05All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Domain.Entities;

namespace DocsManager.Domain.DocumentTypes
{
    public class RtfDocument : BaseDocument
    {
        public override void ProcessDocument()
        {
            DocumentFile = FileStream.ToArray();
            FileType = DocumentTypesEnum.Rtf;
            FileStream.Close();
        }
    }
}