using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Portifolio.Domain.Entities.MinIO;
using Portifolio.Domain.MinIO;
using Portifolio.Utils.Configurations;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Portifolio.Utils.MinIO
{
    public class MinIOUtils : IMinIO
    {
        private readonly IConfigurationRoot _conf;

        private readonly MinIOConfigurations _configuration;

        private readonly MinioClient _MinIOClient;

        private FileStream stream;

        private string DirectoryFile;

        private string AssemblyPath = Assembly.GetAssembly(typeof(MinIOUtils)).Location;

        public MinIOUtils()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("MinIO").Get<MinIOConfigurations>();
            _MinIOClient = ConfigureMinIO();
            CreateBucket();
            DirectoryFile = Path.Combine(AssemblyPath.Substring(0, AssemblyPath.IndexOf(Assembly.GetAssembly(typeof(MinIOUtils)).ManifestModule.Name)), _configuration.TempFile);
        }

        public async Task<string> UploadFiles(IFormFile file)
        {
            string nomeArquivoUpload = "";
            try
            {
                byte[] FileBytes = GetFileBytes(file);

                nomeArquivoUpload = String.Format("{0}.{1}", Guid.NewGuid(), file.FileName.Split('.').LastOrDefault());

                await _MinIOClient.PutObjectAsync(_configuration.Buckets.gallery, nomeArquivoUpload, new MemoryStream(FileBytes), file.Length, file.ContentType);
            }
            catch (Exception)
            {
                throw;
            }

            return nomeArquivoUpload;
        }

        public async Task<bool> DeleteFile(string name)
        {
            RemoveObjectArgs args = new RemoveObjectArgs()
                .WithBucket(_configuration.Buckets.gallery)
                .WithObject(name);

            await _MinIOClient.RemoveObjectAsync(args);

            return true;
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
                    Directory.CreateDirectory(DirectoryFile);
            
            using (stream = new FileStream(Path.Combine(DirectoryFile, file.FileName), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Delete))
            {
                file.CopyTo(stream);
                stream.Close();
            }

            var files = Directory.GetFiles(DirectoryFile);

            var fileBytes = File.ReadAllBytes(files[0]);

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