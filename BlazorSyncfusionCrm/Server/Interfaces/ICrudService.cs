using System.Linq.Expressions;

namespace BlazorSyncfusionCrm.Server.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        Task<List<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(int id, T item);
        Task<List<T>> DeleteAsync(int id);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
