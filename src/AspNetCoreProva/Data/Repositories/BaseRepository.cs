using Application.Domain.Entities;
using Application.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MovieDbContext _context;

        public BaseRepository(MovieDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TEntity>> ToList()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }        

        public async Task Insert(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
        }

        public async Task Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
            await Task.CompletedTask;
        }

        public async Task Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            await Task.CompletedTask;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
