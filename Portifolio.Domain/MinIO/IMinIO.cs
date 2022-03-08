using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Portifolio.Domain.MinIO
{
    public interface IMinIO
    {
        public Task<bool> UploadFiles(IFormFile file);

        public bool DeleteFile();
    }
}
