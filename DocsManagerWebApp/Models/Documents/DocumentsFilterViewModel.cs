// //DocumentsFilterViewModel.cs
// // Copyright (c) 2018 06 29All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Bll.Dto;
using DocsManagerWebApp.Models.Base;

namespace DocsManagerWebApp.Models.Documents
{
    public class DocumentsFilterViewModel : PagingFilterModel
    {
        public static explicit operator DocumentsFilterDto(DocumentsFilterViewModel filterViewModel)
        {
            return new DocumentsFilterDto
            {
                CountOnPage = filterViewModel.CountOnPage,
                Offset = filterViewModel.Offset
            };
        }


    }
}