using Clean.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Clean.Data.Interfaces;

namespace Clean.API
{
    public static class ConfigureContainerExtension
    {
        public static void AddDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CareHomeContext>(options => 
                options.UseSqlite(GetConnectionStringFromConfig()));
        } 

        private static string GetConnectionStringFromConfig()
        {
            return new DatabaseConfiguration().GetDataConnectionString();
        }

        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IAppRepository<>), typeof(AppRepository<>));
        }
    }
}
