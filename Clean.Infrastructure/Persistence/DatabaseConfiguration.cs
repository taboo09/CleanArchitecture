using Microsoft.Extensions.Configuration;
using static Clean.Infrastructure.Persistence.DatabaseConfiguration;

namespace Clean.Infrastructure.Persistence
{
    public partial class DatabaseConfiguration : ConfigurationBase
    {
        private string DataConnectionKey = "Default-sqllite";
        public string GetDataConnectionString() => GetConfiguration().GetConnectionString(DataConnectionKey);
    }
}