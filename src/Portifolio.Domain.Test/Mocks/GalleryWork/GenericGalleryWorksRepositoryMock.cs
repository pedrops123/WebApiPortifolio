using Moq;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Collections.Generic;

namespace Portifolio.Domain.Test.Mocks.GalleryWork
{
    public sealed class GenericGalleryWorksRepositoryMock
    {
        public readonly Mock<IGenericRepository<GalleryWorks>> Instance;

        public GenericGalleryWorksRepositoryMock()
        {
            Instance = new Mock<IGenericRepository<GalleryWorks>>();
        }

        public GenericGalleryWorksRepositoryMock SetupSuccessList(List<GalleryWorks> expected)
        {
            Instance.Setup(r => r.List())
                .ReturnsAsync(expected);

            return this;
        }

        public GenericGalleryWorksRepositoryMock SetupSuccessGetById(int id, GalleryWorks expected)
        {
            Instance.Setup(r => r.GetEntityById(id))
                .ReturnsAsync(expected);

            return this;
        }
    }
}
