using Audi100.Models;

namespace Audi100.Services
{
    public interface IService<T, TKey>
    {
        Task<IList<T>> GetListAsync();
        Task<T> GetByKeyAsync(TKey key);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(TKey key);
    }

}
