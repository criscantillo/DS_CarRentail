using System.Linq.Expressions;

namespace DS_CarRentail.Infrastructure.Shared
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllWhitFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> Get(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);
    }
}
