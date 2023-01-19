using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Delete;
using Portifolio.Domain.Command.Handlers.GalleryWork.Delete;
using Portifolio.Domain.Command.Profiles.GalleryWork;
using Portifolio.Domain.Entities;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Test.Mocks.GalleryWork;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.GalleryWork.Delete
{
    public sealed class DeleteGalleryWorkCommandHandleTest
    {
        private readonly IMapper _mapper;

        public DeleteGalleryWorkCommandHandleTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<GalleryWorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();

            var request = fixture.Build<DeleteGalleryWorksRequest>().Create();

            var minIoService = new Mock<IMinIO>();

            var galleryWorksRepository = new GenericGalleryWorksRepositoryMock()
                .SetupSuccessGetById(request.Id, fixture.Create<GalleryWorks>()).Instance;

            var handle = new DeleteGalleryWorksHandle(
                galleryWorksRepository.Object,
                minIoService.Object
            );

            var response = await handle.Handle(request, default);

            Assert.Equal(Unit.Value, response);
        }
    }
}