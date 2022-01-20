using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Portifolio.Infrastructure.Database.EntityFramework
{
    public static class OptionsBuilderConfiguration
    {
        public static void ConfigureDbContext(this DbContextOptionsBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
            
            var connectionStrings = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionStrings);
        }
    }
}
