﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocsManager.Domain.BaseEntities;

namespace DocsManager.IDal
{
    public interface IRepository<TEntity> where TEntity : IIdEntity
    {
        Task<TEntity> AddAsync(TEntity value);
        Task<TEntity> UpdateAsync(TEntity value);
        Task RemoveAsync(int id);
        IQueryable<TEntity> GetItemsQuery();
    }
}
