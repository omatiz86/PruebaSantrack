using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BnSatrack.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(EFContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
