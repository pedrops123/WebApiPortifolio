using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Command.Handlers.Work.Delete;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Test.Mocks.GalleryWork;
using Portifolio.Domain.Test.Mocks.Work;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.Delete
{
    public sealed class DeleteWorkCommandHandleTest
    {
        private readonly IMapper _mapper;

        public DeleteWorkCommandHandleTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();

            int id = 1;

            var minIOService = new Mock<IMinIO>();

            var expectedGalleryWorks = fixture.CreateMany<GalleryWorks>();

            var galleryWorksRepository = new GenericGalleryWorksRepositoryMock()
                .SetupSuccessList(expectedGalleryWorks.ToList()).Instance;

            var expectedWork = fixture.Create<Works>();

            var worksRepository = new GenericWorksRepositoryMock()
                .SetupSuccessGetById(id, expectedWork).Instance;

            var request = fixture.Build<DeleteWorksRequest>()
                .With(r => r.Id, id).Create();

            var handle = new DeleteWorksHandle(
                _mapper,
                minIOService.Object,
                galleryWorksRepository.Object,
                worksRepository.Object
                );

            var response = await handle.Handle(request, default);

            Assert.Equal(Unit.Value, response);
        }
    }
}