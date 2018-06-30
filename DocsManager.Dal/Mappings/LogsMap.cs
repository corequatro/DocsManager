﻿// //LogsMap.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System.Data.Entity.ModelConfiguration;

namespace DocsManager.Dal.Mappings
{
    public class LogsMap : EntityTypeConfiguration<Domain.Logs>
    {
        public LogsMap()
        {
            HasKey(x => x.Id);
        }
    }
}