
using Clean.Architecture.Domain.DataBase;
using System.Linq.Expressions;

namespace Clean.Architecture.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task UpdateAsync(T entity);
        Task<bool> RemoveAsync(Guid id);
    }
}
