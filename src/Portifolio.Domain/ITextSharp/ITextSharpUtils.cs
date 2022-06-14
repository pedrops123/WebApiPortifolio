using System.Threading.Tasks;

namespace Portifolio.Domain.ITextSharp
{
    public interface ITextSharpUtils
    {
        Task<ResponseCreatePdf> CreateDocument();
    }
}
