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
        public DocumentTypesEnum FileType { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Application { get; set; }
        public string Company { get; set; }
        public string Manager { get; set; }

        public static explicit operator DocumentDto(Document documentDto)
        {
            return new DocumentDto
            {
                Id = documentDto.Id,
                DocumentFile = documentDto.DocumentFile,
                FileName = documentDto.FileName,
                FileType = documentDto.FileType,
                CreatedBy = documentDto.CreatedBy,
                Company = documentDto.Company,
                Manager = documentDto.Manager,
                FileSize = documentDto.FileSize
            };
        }
    }
}