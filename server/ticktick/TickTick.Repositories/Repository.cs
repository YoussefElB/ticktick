using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TickTick.Data;
using TickTick.Models;

namespace TickTick.Repositories
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
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
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _modelDbSet.Attach(entity);
            _dbContext.Entry(entity).State= EntityState.Modified;
        }
    }
}
