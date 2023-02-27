using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TickTick.Data;
using TickTick.Models;

namespace TickTick.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TickTickDbContext _dbContext;
        private readonly DbSet<T> _modelDbSet;
        public Repository(TickTickDbContext db)
        {
            _dbContext = db;
            _modelDbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _modelDbSet.Attach(entity);
            _dbContext.Remove(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            using (_dbContext)
            {
                return await _dbContext.Set<T>()
                .FirstAsync(predicate);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _modelDbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
