// //DocFormatType.cs
// // Copyright (c) 2018 07 01All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using DocsManager.Domain.DocumentTypes;
using DocsManager.Domain.Entities;

namespace DocsManagerWebApp.Factories
{
    public class DocumentFactory
    {
        private const string DocHex = "D0-CF-11-E0-A1-B1";
        private const string DocxHex = "50-4B-03-04-14-00";
        private const string RtfHex = "7B-5C-72-74-66-31";

        private static readonly Dictionary<string, BaseDocument> Documents = new Dictionary<string, BaseDocument>
        {
            {DocxHex,new DocxDocument()},
            {DocHex,new DocDocument()},
            {RtfHex, new RtfDocument()}
        };

        public BaseDocument BuildDocumentForProcessing(HttpPostedFileBase file)
        {
            string fileData;
            var docStream = new MemoryStream();
            file.InputStream.CopyTo(docStream);

            using (BinaryReader binaryReader = new BinaryReader(file.InputStream))
            {
                binaryReader.BaseStream.Position = 0x0;
                byte[] data = binaryReader.ReadBytes(0x10);
                fileData = BitConverter.ToString(data).Substring(0, 17);
            }

            var document = Documents[fileData];
            document.FileName = file.FileName;
            document.FileSize = (int)docStream.Length;
            document.FileStream = docStream;
            return document;
        }
        
        public string GetMimeTypeByFormatType(DocumentTypesEnum docType)
        {
            switch (docType)
            {
                case DocumentTypesEnum.Doc:
                    return "application/msword";
                case DocumentTypesEnum.Docx:
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case DocumentTypesEnum.Rtf:
                    return "application/rtf";
            }
            return "";
        }

    }
}