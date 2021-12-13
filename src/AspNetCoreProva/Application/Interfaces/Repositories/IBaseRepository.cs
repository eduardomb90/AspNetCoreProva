using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> ToList();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);        
        Task Insert(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task<int> SaveChanges();
        
    }
}
