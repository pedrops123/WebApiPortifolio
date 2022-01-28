using Microsoft.Extensions.Configuration;
using System.IO;

namespace Portifolio.Domain.Query.Configurations
{
    public static class ConfigurationRootFactory
    {
        public static IConfigurationRoot SetConfigurationRootBuilder()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return configuration;
        } 
    }
}
