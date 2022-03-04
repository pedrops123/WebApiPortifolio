using Microsoft.AspNetCore.Http;

namespace Portifolio.Domain.MinIO
{
    public interface IMinIO
    {
        public bool UploadFiles(IFormFile file);

        public bool DeleteFile();
    }
}
