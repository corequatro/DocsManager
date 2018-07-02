using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using DocsManager.Dal;
using DocsManager.Domain.BaseEntities;
using DocsManager.IDal;

namespace DocsManager.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IIdEntity
    {
        private readonly DocsManagerDbContext _context;

        public Repository(DocsManagerDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity value)
        {
            value.Id = 0;
            value.CreatedDate = DateTime.Now;
            var entity = _context.Set<TEntity>().Add(value);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity value)
        {
            value.UpdatedDate = DateTime.Now;
            _context.Entry(value).State = EntityState.Modified;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }




Visual Studio Installer

        public async Task<TEntity> GetItemByIdAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<TEntity> GetItemsQuery()
        {
            return _context.Set<TEntity>().AsNoTracking().AsQueryable();
        }
    }
}
