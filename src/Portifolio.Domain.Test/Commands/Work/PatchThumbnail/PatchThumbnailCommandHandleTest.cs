using AutoFixture;
using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Command.Handlers.Work.PatchThumbnail;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Test.Mocks.GalleryWork;
using Portifolio.Domain.Test.Mocks.Work;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.PatchThumbnail
{
    public sealed class PatchThumbnailCommandHandleTest
    {
        private readonly IMapper _mapper;

        public PatchThumbnailCommandHandleTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();

            var request = fixture.Create<PatchThumbnailWorksRequest>();

            var expectedGalleryWorks = fixture.Create<GalleryWorks>();

            var expectedWork = fixture.Create<Works>();

            var workGalleryRepository = new GenericGalleryWorksRepositoryMock()
                .SetupSuccessGetById(request.ImgThumbnailId, expectedGalleryWorks).Instance;

            var workRepository = new GenericWorksRepositoryMock()
                .SetupSuccessGetById(request.Id, expectedWork).Instance;

            var handle = new PatchThumbnailWorkHandle(
                _mapper,
                workGalleryRepository.Object,
                workRepository.Object);

            var response = await handle.Handle(request, default);

            Assert.Equal(Unit.Value, response);
        }
    }
}