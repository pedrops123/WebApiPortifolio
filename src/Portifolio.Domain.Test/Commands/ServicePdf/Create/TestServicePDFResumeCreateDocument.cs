using AutoFixture;
using Portifolio.Domain.Test.Mocks.ServicePdf;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.ServicePdf.Create
{

    public sealed class TestServicePDFResumeCreateDocument
    {
        [Fact]
        public async Task Generate_Resume_ReturnsValidFile()
        {
            var fixture = new Fixture();

            var servicePdf = new ServicePdfMock().SetupSuccessGenerateFile().Instance.Object;

            var response = await servicePdf.CreateDocument();

            Assert.NotEmpty(response.ContentType);

            Assert.NotEmpty(response.FileBytes);

            Assert.NotEmpty(response.FileName);
        }
    }
}