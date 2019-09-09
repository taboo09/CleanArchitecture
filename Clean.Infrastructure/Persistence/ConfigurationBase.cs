using System;
using Microsoft.Extensions.Configuration;

namespace Clean.Infrastructure.Persistence
{
    public abstract class ConfigurationBase
    {
        protected IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}