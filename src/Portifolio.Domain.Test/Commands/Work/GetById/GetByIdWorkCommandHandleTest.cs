using AutoFixture;
using AutoMapper;
using Moq;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Handlers.Work.GetById;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Test.Mocks.Work;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.GetById
{
    public sealed class GetByIdWorkCommandHandleTest
    {
        private readonly IMapper _mapper;

        public GetByIdWorkCommandHandleTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsValidObject()
        {
            var fixture = new Fixture();
            var expected = fixture.Create<Works>();
            var minIoService = new Mock<IMinIO>();

            var parameters = fixture.Build<GetByIdWorksRequest>().Create();

            var galleryWorksRepository = new Mock<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>>();

            var worksRepository = new GenericWorksQueryRepositoryMock()
                .SetupSuccessGetById(parameters.Id, expected).Instance;

            var handle = new GetByIdWorkHandle(
                _mapper,
                minIoService.Object,
                galleryWorksRepository.Object,
                worksRepository.Object);

            var response = await handle.Handle(parameters, default);

            Assert.NotNull(response);
        }

        [Fact]
        public async Task Handle_InvalidData_ReturnsNullObject()
        {
            var fixture = new Fixture();
            var minIoService = new Mock<IMinIO>();

            var parameters = fixture.Build<GetByIdWorksRequest>().Create();

            var galleryWorksRepository = new Mock<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>>();

            var worksRepository = new GenericWorksQueryRepositoryMock()
                .SetupSuccessGetById(parameters.Id, null).Instance;

            var handle = new GetByIdWorkHandle(
                _mapper,
                minIoService.Object,
                galleryWorksRepository.Object,
                worksRepository.Object);

            await Assert.ThrowsAsync<Exception>(() => handle.Handle(parameters, default));
        }
    }
}