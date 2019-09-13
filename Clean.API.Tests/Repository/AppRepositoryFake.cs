using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.Data.Entities;
using Clean.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Clean.API.Tests.Data;
using Clean.Infrastructure.Persistence;

namespace Clean.API.Tests.Repository
{
    public class AppRepositoryFake : IAppRepository<Homes>
    {
        private CareHomeContext _dbContext;
        public AppRepositoryFake()
        {
            _dbContext = new DbContextMocker().SetDbContext<Homes>();
        }

        public async Task<IReadOnlyList<Homes>> ListAllAsync()
        {
            var list = await _dbContext.Homes.ToListAsync();
            
            return list;
        }

        public Homes Add(Homes entity)
        {
            _dbContext.Homes.Add(entity);
            
            return entity;
        }

        public void  Delete(Homes entity)
        {
            _dbContext.Homes.Remove(entity);
        }

        public async Task<Homes> GetByIdAsync(int id)
        {
            var obj = await _dbContext.Homes.FirstOrDefaultAsync(x => x.Id == id);

            return obj;
        }  

        public async Task SaveAllAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}