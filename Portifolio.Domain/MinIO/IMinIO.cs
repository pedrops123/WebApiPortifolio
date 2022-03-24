using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Portifolio.Domain.MinIO
{
    public interface IMinIO
    {
        public Task<string> GetFile(string name);
        public Task<string> UploadFiles(IFormFile file);
        public Task<bool> DeleteFile(string name);
    }
}
