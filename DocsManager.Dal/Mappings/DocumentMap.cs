// //DocumentMap.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Data.Entity.ModelConfiguration;
using DocsManager.Domain.Entities;

namespace DocsManager.Dal.Mappings
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            HasKey(x => x.Id);
        }
    }
}