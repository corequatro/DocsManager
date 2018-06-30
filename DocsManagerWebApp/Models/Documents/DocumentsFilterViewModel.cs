// //DocumentsFilterViewModel.cs
// // Copyright (c) 2018 06 29All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Bll.Dto;

namespace DocsManagerWebApp.Models.Documents
{
    public class DocumentsFilterViewModel
    {
        public static explicit operator DocumentsFilterDto(DocumentsFilterViewModel filterViewModel)
        {
            return new DocumentsFilterDto();
        }


    }
}