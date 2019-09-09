using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clean.Infrastructure.Persistence
{

    // IDesignTimeDbContextFactory - used for Migrations
    public class DbContextFactory : IDesignTimeDbContextFactory<CareHomeContext>
        {
            private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

            public CareHomeContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CareHomeContext>();

                optionsBuilder.UseSqlite(DataConnectionString);

                return new CareHomeContext(optionsBuilder.Options);
            }
        }
}