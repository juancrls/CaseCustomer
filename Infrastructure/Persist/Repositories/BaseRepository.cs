using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persist.Repositories
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity
        where TId : struct
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context) => _context = context;

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public bool Exists(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public TEntity? FindById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
