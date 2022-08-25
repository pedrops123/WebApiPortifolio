using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Handlers.Work.Update;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.Update
{
    public sealed class UpdateWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public UpdateWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();
            var repository = new Mock<IGenericRepository<Works>>();
            var request = fixture.Create<UpdateWorksRequest>();

            var handler = new UpdateWorkHandle(
                _mapper,
                repository.Object
                );

            var response = await handler.Handle(request, default);

            Assert.Equal(Unit.Value, response);

            repository.Verify(r => r.Update(It.IsAny<Works>()), Times.Once);
        }
    }
}
