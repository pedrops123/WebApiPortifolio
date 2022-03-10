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

        private FileStream stream;

        private string DirectoryFile;
        public MinIOUtils()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("MinIO").Get<MinIOConfigurations>();
            _MinIOClient = ConfigureMinIO();
            CreateBucket();
            DirectoryFile = Path.Combine(Assembly.GetAssembly(typeof(MinIOUtils)).Location.Substring(0, 31), _configuration.TempFile);
        }

        public async Task<string> UploadFiles(IFormFile file)
        {
            string nomeArquivoUpload = "";
            try
            {
                string PathLocalFile = GetNameLocalFile(file);

                await _MinIOClient.PutObjectAsync(_configuration.Buckets.gallery, file.FileName, PathLocalFile, file.ContentType);

                nomeArquivoUpload = await GetFile(file.FileName);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                DeleteFolderLocalFile();
            }

            return nomeArquivoUpload;
        }

        public bool DeleteFile()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetFile(string name)
        {
            GetObjectArgs args = new GetObjectArgs()
                                              .WithBucket(_configuration.Buckets.gallery)
                                              .WithObject(name)
                                              .WithFile(name);

            var obj = await _MinIOClient.GetObjectAsync(args);

            return obj.ObjectName;
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

            using (stream = new FileStream(Path.Combine(DirectoryFile, file.FileName), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Delete))
            {
                file.CopyTo(stream);
                stream.Close();
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
                    if (File.Exists(file))
                    {
                        GC.Collect();
                        File.Delete(file);
                    }
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
