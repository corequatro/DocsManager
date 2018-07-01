// //DocFormatType.cs
// // Copyright (c) 2018 07 01All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.IO;

namespace DocsManager.Bll.Utils
{
    public enum DocType
    {
        Doc = 1,
        Docx = 2,
        WrongFormat = 3
    };
    public static class DocFormatType
    {
        public const string DocHex = "D0-CF-11-E0-A1-B1-1A-E1";
        public const string DocxHex = "50-4B-03-04-14-00-06-00";

        public static DocType DetermineDocType(BinaryReader binaryReader)
        {
            binaryReader.BaseStream.Position = 0x0;
            byte[] data = binaryReader.ReadBytes(0x10);
            string data_as_hex = BitConverter.ToString(data);
            string fileData = data_as_hex.Substring(0, 23);
            switch (fileData)
            {
                case DocHex:
                    return DocType.Doc;
                case DocxHex:
                    return DocType.Docx;
            }

            return DocType.WrongFormat;
        }
    }
}