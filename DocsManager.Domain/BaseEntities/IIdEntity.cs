// //IIdEntity.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

namespace DocsManager.Domain.BaseEntities
{
    public interface IIdEntity : IBaseEntity
    {
        int Id { get; set; }
    }
}