using Moq;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Generics;

namespace Portifolio.Domain.Test.Mocks.Works
{
    public sealed class GenericQueryRepositoryMock
    {
        private readonly Mock<IGenericQuery<Entities.Works, FilterWorksRequest>> Instance;
        public GenericQueryRepositoryMock()
        {
            Instance = new Mock<IGenericQuery<Entities.Works, FilterWorksRequest>>();
        }

        public GenericQueryRepositoryMock SetupSuccessGetList()
        {
            Instance.Setup(r=>r.GetList())


            return this;
        }
    }
}
