using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Portifolio.Domain.MinIO
{
    public interface IMinIO
    {
        Task<string> GetFile(string name);
        Task<string> UploadFiles(IFormFile file);
        Task<bool> DeleteFile(string name);
    }
}
