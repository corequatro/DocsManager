// //DocumentDto.cs
// // Copyright (c) 2018 06 29All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using DocsManager.Domain.Entities;

namespace DocsManager.Bll.Dto
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public byte[] DocumentFile { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //TODO maybe I should use auto mapper here. 
        public static explicit operator Document(DocumentDto documentDto)
        {
            return new Document
            {
                Id = documentDto.Id,
                DocumentFile = documentDto.DocumentFile,
                FileName = documentDto.FileName,
                FileType = documentDto.FileType,
                CreatedBy = documentDto.CreatedBy,
                FileSize = documentDto.FileSize
            };
        }

        public static explicit operator DocumentDto(Document documentDto)
        {
            return new DocumentDto
            {
                Id = documentDto.Id,
                DocumentFile = documentDto.DocumentFile,
                FileName = documentDto.FileName,
                FileType = documentDto.FileType,
                CreatedBy = documentDto.CreatedBy

            };
        }
    }
}