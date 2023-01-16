using AutoFixture;
using AutoMapper;
using MediatR;
using Moq;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Handlers.Work.Create;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Threading.Tasks;
using Xunit;

namespace Portifolio.Domain.Test.Commands.Work.Create
{
    public sealed class CreateWorkCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public CreateWorkCommandHandlerTest()
        {
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WorksProfile>()).CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidData_ReturnsUnitValue()
        {
            var fixture = new Fixture();
            var repository = new Mock<IGenericRepository<Works>>();
            var request = fixture.Create<CreateWorksRequest>();

            var handler = new CreateWorkHandle(
                repository.Object,
                _mapper);

            var response = await handler.Handle(request, default);

            Assert.Equal(Unit.Value, response);


            repository.Verify(r => r.Add(It.IsAny<Works>()), Times.Once);
        }
    }
}
