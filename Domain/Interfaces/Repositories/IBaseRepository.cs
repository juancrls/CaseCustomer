using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, in TId> where TEntity : class where TId : struct
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        bool Exists(Func<TEntity, bool> where);
        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity? FindById(TId id);
    }
}
