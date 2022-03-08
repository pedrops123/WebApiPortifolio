using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Portifolio.Domain.Entities.MinIO;
using Portifolio.Domain.MinIO;
using Portifolio.Utils.Configurations;

namespace Portifolio.Utils.MinIO
{
    public class MinIOUtils : IMinIO
    {
        private IConfigurationRoot _conf;

        private MinIOConfigurations configuration;

        public MinIOUtils()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            configuration = _conf.GetSection("MinIO").Get<MinIOConfigurations>();
        }

        public bool UploadFiles(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteFile()
        {
            throw new System.NotImplementedException();
        }
    }
}
