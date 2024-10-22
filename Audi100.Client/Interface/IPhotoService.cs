using Audi100.Models;

namespace Audi100.Services
{
    public interface IPhotoService<T, TKey>
    {
        Task<IList<T>> GetListAsync();
        Task<T> GetByKeyAsync(TKey key);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(TKey key);
        Task<IList<T>> GetAuditId(int auditFindingId);

    }

}
