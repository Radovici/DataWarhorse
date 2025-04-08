using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataModels.EntityFramework.Contexts
{
    public class ConfiguredDbContext
        : DbContext
    {
        public ConfiguredDbContext()
            : base()
        {
        }

        public ConfiguredDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile("appsettings.development.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                var connStr = config.GetConnectionString("DataWarhorse");
                optionsBuilder.UseSqlServer(connStr);
            }
        }
    }
}
