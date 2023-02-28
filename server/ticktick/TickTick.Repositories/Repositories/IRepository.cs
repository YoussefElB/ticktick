using System.Linq.Expressions;
using TickTick.Models;

namespace TickTick.Repositories.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task<int> SaveAsync();
    }
}
