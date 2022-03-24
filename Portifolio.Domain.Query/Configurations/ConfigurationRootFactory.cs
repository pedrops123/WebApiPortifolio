using Microsoft.Extensions.Configuration;
using System.IO;

namespace Portifolio.Domain.Query.Configurations
{
    internal static class ConfigurationRootFactory
    {
        internal static IConfigurationRoot SetConfigurationRootBuilder()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return configuration;
        }
    }
}
