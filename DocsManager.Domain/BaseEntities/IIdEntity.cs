// //IIdEntity.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Datascope, Bogdan Lyashenko
// // bohdan.lyashenko@gmail.com

namespace DocsManager.Domain.BaseEntities
{
    public interface IIdEntity : IBaseEntity
    {
        int Id { get; set; }
    }
}