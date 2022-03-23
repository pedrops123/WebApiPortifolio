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

        private string AssemblyPath = Assembly.GetAssembly(typeof(MinIOUtils)).Location;

        public MinIOUtils()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("MinIO").Get<MinIOConfigurations>();
            _MinIOClient = ConfigureMinIO();
            CreateBucket();
            DirectoryFile = Path.Combine(AssemblyPath.Substring(0, AssemblyPath.IndexOf("bin")), _configuration.TempFile);
        }

        public async Task<string> UploadFiles(IFormFile file)
        {
            string nomeArquivoUpload = "";
            try
            {
                byte[] FileBytes = GetFileBytes(file);

                await _MinIOClient.PutObjectAsync(_configuration.Buckets.gallery, file.FileName, new MemoryStream(FileBytes), file.Length, file.ContentType);

                nomeArquivoUpload = file.FileName;
            }
            catch (Exception e)
            {
                throw;
            }

            return nomeArquivoUpload;
        }

        public bool DeleteFile()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetFile(string name)
        {
            var UrlFile = await _MinIOClient.PresignedGetObjectAsync(_configuration.Buckets.gallery, name, 6000);

            return UrlFile;
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

        private byte[] GetFileBytes(IFormFile file)
        {

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

            var fileBytes = System.IO.File.ReadAllBytes(files[0]);

            foreach (string pathFiles in files)
            {
                if (File.Exists(pathFiles))
                {
                    GC.Collect(0, GCCollectionMode.Forced, false);
                    File.Delete(pathFiles);
                }
            }

            Directory.Delete(DirectoryFile);

            return fileBytes;
        }
    }
}