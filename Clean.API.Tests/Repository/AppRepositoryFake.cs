using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.Data.Entities;
using Clean.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace Clean.API.Tests.Repository
{
    public class AppRepositoryFake : IAppRepository<Homes>
    {
        private List<Homes> _homes;
        public AppRepositoryFake()
        {
            _homes = new List<Homes>()
            {
                new Homes() { Id = 1, Name = "Test1", City = "Lichfield", Address = "34 Road", Email = "test@test.com", Rating = 4 },
                new Homes() { Id = 2, Name = "Test2", City = "London", Address = "6 Street", Email = "test@test.com", Rating = 5 }
            };
        }

        public async Task<IReadOnlyList<Homes>> ListAllAsync()
        {
            await Task.Delay(100);

            return _homes;
        }

        public Homes Add(Homes entity)
        {
            _homes.Add(entity);

            return entity;
        }

        public void  Delete(Homes entity)
        {
            _homes.Remove(entity);
        }

        public async Task<Homes> GetByIdAsync(int id)
        {
            await Task.Delay(100);

            return _homes.FirstOrDefault(x => x.Id == id);
        }  

        public async Task SaveAllAsync()
        {
            await Task.Delay(100);
        }
    }
}