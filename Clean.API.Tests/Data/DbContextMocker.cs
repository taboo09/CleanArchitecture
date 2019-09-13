using System;
using Clean.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clean.API.Tests.Data
{
    public class DbContextMocker : IDisposable
    {
        protected readonly CareHomeContext _dbContext;
        public DbContextMocker()
        {
            // Create options for DbContext instance
            // Use Guid to create a new db every time the class is instatiated
            var options = new DbContextOptionsBuilder<CareHomeContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            // Create instance of DbContext
            _dbContext = new CareHomeContext(options);

            _dbContext.Database.EnsureCreated();            
        }

        public CareHomeContext SetDbContext<T>() where T : class
        {
            // Add fake etitites in memory
            SeedDatabase.Initialize<T>(_dbContext);

            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();

            _dbContext.Dispose();
        }
    }
}