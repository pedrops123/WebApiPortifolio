using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Portifolio.Domain.Entities.MinIO;
using Portifolio.Domain.MinIO;
using Portifolio.Utils.Configurations;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Portifolio.Utils.MinIO
{
    public class MinIOUtils : IMinIO
    {
        private IConfigurationRoot _conf;

        private MinIOConfigurations _configuration;

        private MinioClient _MinIOClient;

        private string DirectoryFile;
        public MinIOUtils()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("MinIO").Get<MinIOConfigurations>();
            _MinIOClient = ConfigureMinIO();
            CreateBucket();
            DirectoryFile = Path.Combine(Assembly.GetAssembly(typeof(MinIOUtils)).Location.Substring(0, 31), _configuration.TempFile);
        }

        public async Task<bool> UploadFiles(IFormFile file)
        {
            bool result = false;
            try
            {
                string PathLocalFile = GetNameLocalFile(file);

                await _MinIOClient.PutObjectAsync(_configuration.Buckets.gallery, file.FileName, PathLocalFile, file.ContentType);

                result = true;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                DeleteFolderLocalFile();
            }
            return result;
        }

        public bool DeleteFile()
        {
            throw new System.NotImplementedException();
        }

        private MinioClient ConfigureMinIO()
        {
            MinioClient minIOClient = new MinioClient()
                 .WithEndpoint(_configuration.Connection.Server)
                 .WithCredentials(_configuration.Credentials.Admin.AccessKey, _configuration.Credentials.Admin.SecretKey)
                 .Build();

            return minIOClient;
        }

        private async Task CreateBucket()
        {
            BucketExistsArgs args = new BucketExistsArgs()
                .WithBucket(_configuration.Buckets.gallery);

            var found = GetExistBucket(args);

            found.Wait();

            if (!found.Result)
            {
                await _MinIOClient.MakeBucketAsync(
                    new MakeBucketArgs()
                     .WithBucket(_configuration.Buckets.gallery)
                    );
            }
        }

        private async Task<bool> GetExistBucket(BucketExistsArgs args)
        {
            bool found = await _MinIOClient.BucketExistsAsync(args);

            return found;
        }

        private string GetNameLocalFile(IFormFile file)
        {
            string FileName;

            if (!Directory.Exists(DirectoryFile))
            {
                Directory.CreateDirectory(DirectoryFile);
            }

            using (Stream stream = new FileStream(Path.Combine(DirectoryFile, file.FileName), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.CopyTo(stream);
                stream.Flush();
                stream.Close();
                stream.Dispose();
            }

            var files = Directory.GetFiles(DirectoryFile);

            FileName = files[0];

            return FileName;
        }

        private void DeleteFolderLocalFile()
        {
            var files = Directory.GetFiles(DirectoryFile);

            try
            {
                foreach (string file in files)
                {
                    File.Delete(file);
                }

                Directory.Delete(DirectoryFile);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
