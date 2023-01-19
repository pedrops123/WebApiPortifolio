using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Command.Handlers.GalleryWork.Create;
using Portifolio.Domain.Command.Profiles.GalleryWork;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Test.Mocks;
using Portifolio.Domain.Test.Mocks.Work;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.GalleryWork.Create
{
    public sealed class CreateGalleryWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public CreateGalleryWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<GalleryWorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();

            var repository = new Mock<IGenericRepository<GalleryWorks>>();
            var minIoService = new Mock<IMinIO>();

            fixture.Customize<CreateGalleryWorksRequest>(r =>
                r.FromFactory(() => new CreateGalleryWorksRequest(new Random().Next(), CreateIFileFormCollectionMock.GenerateIFileFormCollection("teste.jpg"))));

            var request = fixture.Create<CreateGalleryWorksRequest>();

            var worksRepository =
                new GenericWorksRepositoryMock().SetupSuccessGetById(request.ProjectId, fixture.Create<Works>()).Instance;

            var handler = new CreateGalleryWorksHandle(
                worksRepository.Object,
                repository.Object,
                minIoService.Object,
                _mapper);

            var response = await handler.Handle(request, default);

            Assert.Equal(Unit.Value, response);

            repository.Verify(r => r.AddRange(It.IsAny<List<GalleryWorks>>()), Times.Once);
        }
    }
}