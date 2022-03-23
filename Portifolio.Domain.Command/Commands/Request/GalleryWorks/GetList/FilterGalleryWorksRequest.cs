using MediatR;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList
{
    public class FilterGalleryWorksRequest : IRequest<IEnumerable<FilterGalleryWorksResponse>>
    {
       
        public int IdProjeto { get; set; }

        public FilterGalleryWorksRequest()
        { }
      
        public FilterGalleryWorksRequest(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
    }
}