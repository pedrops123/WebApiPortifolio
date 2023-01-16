using Moq;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Collections.Generic;

namespace Portifolio.Domain.Test.Mocks.GalleryWork
{
    public sealed class GenericGalleryWorkQueryRepositoryMock
    {
        public readonly Mock<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>> Instance;

        public GenericGalleryWorkQueryRepositoryMock()
        {
            Instance = new Mock<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>>();
        }

        public GenericGalleryWorkQueryRepositoryMock SetupSuccessGetList(FilterGalleryWorksRequest parameters, List<GalleryWorks> expected)
        {
            Instance.Setup(r => r.GetList(parameters))
                .ReturnsAsync(expected);

            return this;
        }

        public GenericGalleryWorkQueryRepositoryMock SetupSuccessGetById(int id, GalleryWorks expected)
        {
            Instance.Setup(r => r.GetById(id))
                .ReturnsAsync(expected);

            return this;
        }
    }
}