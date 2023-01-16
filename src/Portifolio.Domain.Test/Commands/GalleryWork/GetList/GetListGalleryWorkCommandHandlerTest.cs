using AutoFixture;
using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Handlers.GalleryWork.GetList;
using Portifolio.Domain.Command.Profiles.GalleryWork;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Test.Mocks.GalleryWork;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.GalleryWork.GetList
{
    public sealed class GetListGalleryWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public GetListGalleryWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<GalleryWorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsListValue()
        {
            var fixture = new Fixture();
            var parameters = fixture.Create<FilterGalleryWorksRequest>();

            var dapperGalleryWorksRepository = new GenericGalleryWorkQueryRepositoryMock()
                .SetupSuccessGetList(parameters, fixture.CreateMany<GalleryWorks>().ToList()).Instance;

            var handle = new GetListGalleryWorksHandle(
                _mapper,
                dapperGalleryWorksRepository.Object
            );

            var response = await handle.Handle(parameters, default);

            Assert.NotEmpty(response);
        }
    }
}