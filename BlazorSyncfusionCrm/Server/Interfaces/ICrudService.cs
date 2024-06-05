namespace BlazorSyncfusionCrm.Server.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        Task<List<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(int id);
    }
}
