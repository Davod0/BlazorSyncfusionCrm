using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Server.Interfaces;
using BlazorSyncfusionCrm.Server.Services;
using BlazorSyncfusionCrm.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor.RichTextEditor;

namespace BlazorSyncfusionCrm.Server.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, ISoftDelete
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public CrudService(DataContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> result = await _dbSet.Where(item => item.IsDeleted == false).ToListAsync();
            if(result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id cannot be null");
            }
            T result = await _dbSet.FindAsync(id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<T> AddAsync(T item)
        {

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            try
            {
                await _dbSet.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog, NLog, etc.)
                Console.Error.WriteLine($"An error occurred while adding the item: {ex.Message}");
                // You can rethrow the exception if you want it to be handled at a higher level, or return null
                // throw;
                return null;
            }
        }

       public async Task<T> UpdateAsync(int id, T item)
       {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            var existingItem = await _dbSet.FindAsync(id);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingItem;
       }

        public async Task<List<T>> DeleteAsync(int id) 
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            item.IsDeleted = true;
            item.DateDeleted = DateTime.Now;
            await _context.SaveChangesAsync();
            return await GetAllAsync();
        }

    }
}


