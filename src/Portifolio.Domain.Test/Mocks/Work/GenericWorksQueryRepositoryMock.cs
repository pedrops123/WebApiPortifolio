using Moq;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Collections.Generic;

namespace Portifolio.Domain.Test.Mocks.Work
{
    public sealed class GenericWorksQueryRepositoryMock
    {
        public readonly Mock<IGenericQuery<Works, FilterWorksRequest>> Instance;

        public GenericWorksQueryRepositoryMock()
        {
            Instance = new Mock<IGenericQuery<Works, FilterWorksRequest>>();
        }

        public GenericWorksQueryRepositoryMock SetupSuccessGetList(FilterWorksRequest parameters, List<Works> expected)
        {
            Instance.Setup(r => r.GetList(parameters))
                .ReturnsAsync(expected);

            return this;
        }

        public GenericWorksQueryRepositoryMock SetupSuccessGetById(int id, Works expected)
        {
            Instance.Setup(r => r.GetById(id))
                .ReturnsAsync(expected);

            return this;
        }
    }
}