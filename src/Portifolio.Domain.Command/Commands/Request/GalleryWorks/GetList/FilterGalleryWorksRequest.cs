using MediatR;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList
{
    public sealed class FilterGalleryWorksRequest : IRequest<IEnumerable<FilterGalleryWorksResponse>>
    {

        public int ProjectId { get; set; }

        public FilterGalleryWorksRequest()
        { }

        public FilterGalleryWorksRequest(int projectId)
        {
            ProjectId = projectId;
        }
    }
}