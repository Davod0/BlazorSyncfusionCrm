using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Server.Interfaces;
using BlazorSyncfusionCrm.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorSyncfusionCrm.Server.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public CrudService(DataContext context) 
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


    }
}


