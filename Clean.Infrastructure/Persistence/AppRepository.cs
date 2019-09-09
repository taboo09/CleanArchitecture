using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Persistence
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        private readonly CareHomeContext _dbContext;

        public AppRepository(CareHomeContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

         public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }
        
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAllAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}