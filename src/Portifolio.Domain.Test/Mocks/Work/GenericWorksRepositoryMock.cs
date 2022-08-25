using Moq;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;

namespace Portifolio.Domain.Test.Mocks.Work
{
    public sealed class GenericWorksRepositoryMock
    {
        public readonly Mock<IGenericRepository<Works>> Instance;

        public GenericWorksRepositoryMock()
        {
            Instance = new Mock<IGenericRepository<Works>>();
        }

        public GenericWorksRepositoryMock SetupSuccessGetById(int id, Works expected)
        {
            Instance.Setup(r => r.GetEntityById(id))
                .ReturnsAsync(expected);

            return this;
        }
    }
}
