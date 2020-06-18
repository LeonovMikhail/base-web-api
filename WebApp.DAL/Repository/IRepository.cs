using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApp.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity model);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity model);
        Task Delete(Guid id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where);
    }
}