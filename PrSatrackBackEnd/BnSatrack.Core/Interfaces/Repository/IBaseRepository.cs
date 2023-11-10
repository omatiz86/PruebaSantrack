using BnSatrack.Core.Entites;
using System.Linq.Expressions;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        bool Delete(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        List<TEntity> List(Expression<Func<TEntity, bool>> expression);


    }
}
