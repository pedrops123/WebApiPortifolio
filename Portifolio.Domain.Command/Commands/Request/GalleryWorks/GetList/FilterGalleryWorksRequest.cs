using MediatR;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList
{
    public class FilterGalleryWorksRequest : IRequest<FilterGalleryWorksResponse>
    {
        public int IdProjeto { get; set; }

        public FilterGalleryWorksRequest(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
    }
}