using Moq;
using Portifolio.Domain.ITextSharp;

namespace Portifolio.Domain.Test.Mocks.ServicePdf
{
    public sealed class ServicePdfMock
    {
        public readonly Mock<ITextSharpUtils> Instance;

        public ServicePdfMock()
        {
            Instance = new Mock<ITextSharpUtils>();
        }

        public ServicePdfMock SetupSuccessGenerateFile()
        {
            byte[] bytes = { 12, 14, 40 };

            Instance.Setup(r => r.CreateDocument())
                .ReturnsAsync(new ResponseCreatePdf("teste.pdf", bytes));

            return this;
        }
    }
}