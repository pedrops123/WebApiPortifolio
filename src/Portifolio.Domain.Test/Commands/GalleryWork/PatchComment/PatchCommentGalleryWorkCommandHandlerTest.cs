using AutoFixture;
using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment;
using Portifolio.Domain.Command.Handlers.GalleryWork.PatchComment;
using Portifolio.Domain.Command.Profiles.GalleryWork;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Test.Mocks.GalleryWork;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.GalleryWork.PatchComment
{
    public sealed class PatchCommentGalleryWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public PatchCommentGalleryWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<GalleryWorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();

            var request = fixture.Create<PatchGalleryWorksCommentRequest>();

            var expectedGalleryWorks = fixture.Create<GalleryWorks>();

            var workGalleryRepository = new GenericGalleryWorksRepositoryMock()
                .SetupSuccessGetById(request.Id, expectedGalleryWorks).Instance;

            var handle = new PatchCommentGalleryWorksHandle(
                workGalleryRepository.Object,
                _mapper);

            var response = await handle.Handle(request, default);

            Assert.Equal(Unit.Value, response);
        }
    }
}