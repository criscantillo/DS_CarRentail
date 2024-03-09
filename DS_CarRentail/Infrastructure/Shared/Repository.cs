using DS_CarRentail.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DS_CarRentail.Infrastructure.Shared
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CarRentailContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CarRentailContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var dataToDelete = await _dbSet.FindAsync(id);
            if(dataToDelete is not null)
            {
                _dbSet.Remove(dataToDelete);
            }
        }

        public async Task<TEntity?> Get(int id)
        {
            TEntity? entityData = await _dbSet.FindAsync(id);
            return entityData;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> lstData = await _dbSet.ToListAsync();
            return lstData;
        }

        public async Task<IEnumerable<TEntity>> GetAllWhitFilter(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> lstData = await _dbSet.Where(filter).ToListAsync();
            return lstData;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
