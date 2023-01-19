using AutoFixture;
using AutoMapper;
using Moq;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Handlers.Work.GetList;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Test.Mocks.Work;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.GetList
{
    public sealed class GetListWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public GetListWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsListValue()
        {
            var fixture = new Fixture();
            var minIoService = new Mock<IMinIO>();

            var parameters = fixture.Create<FilterWorksRequest>();
            var expected = fixture.CreateMany<Works>();

            var dapperGalleryWorksRepository = new Mock<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>>();

            var dapperWorksRepository = new GenericWorksQueryRepositoryMock()
                .SetupSuccessGetList(parameters, expected.ToList()).Instance;

            var handle = new GetListWorkHandle(
                _mapper,
                minIoService.Object,
                dapperGalleryWorksRepository.Object,
                dapperWorksRepository.Object
                );

            var response = await handle.Handle(parameters, default);

            Assert.NotEmpty(response);
        }
    }
}
