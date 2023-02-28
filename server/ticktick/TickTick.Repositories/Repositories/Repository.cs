using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TickTick.Data;
using TickTick.Models;

namespace TickTick.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
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
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
            .FirstAsync(predicate);
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            using (_dbContext)
            {
                _modelDbSet.Attach(entity);
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
