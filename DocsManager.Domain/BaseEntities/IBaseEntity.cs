// //IBaseEntity.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

using System;

namespace DocsManager.Domain.BaseEntities
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}