// //DocFormatType.cs
// // Copyright (c) 2018 07 01All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DocsManager.Bll.Dto;
using DocsManager.Domain.DocumentTypes;

namespace DocsManagerWebApp.Factories
{
    public static class DocumentFactory
    {
        private const string DocHex = "D0-CF-11-E0-A1-B1";
        private const string DocxHex = "50-4B-03-04-14-00";
        private const string RtfHex = "7B-5C-72-74-66-31";

        public static readonly Dictionary<string, BaseDocument> Documents = new Dictionary<string, BaseDocument>
        {
            {DocxHex,new DocxDocument()},
            {DocHex,new DocDocument()}
        };

        public static BaseDocument DetermineDocType(HttpPostedFileBase file)
        {
            using (BinaryReader binaryReader = new BinaryReader(file.InputStream))
            {
                binaryReader.BaseStream.Position = 0x0;
                byte[] data = binaryReader.ReadBytes(0x10);
                string data_as_hex = BitConverter.ToString(data);
                string fileData = data_as_hex.Substring(0, 17);
                return Documents[fileData];
            }
        }

        //public static DocumentTypesEnum DetermineDocType(BinaryReader binaryReader)
        //{
        //    binaryReader.BaseStream.Position = 0x0;
        //    byte[] data = binaryReader.ReadBytes(0x10);
        //    string data_as_hex = BitConverter.ToString(data);
        //    string fileData = data_as_hex.Substring(0, 17);
        //    switch (fileData)
        //    {
        //        case DocHex:
        //            return DocumentTypesEnum.Doc;
        //        case DocxHex:
        //            return DocumentTypesEnum.Docx;
        //        case RtfHex:
        //            return DocumentTypesEnum.Rtf;
        //    }

        //    return DocumentTypesEnum.WrongFormat;
        //}

        public static string GetMimeTypeByFormatType(DocumentTypesEnum docType)
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