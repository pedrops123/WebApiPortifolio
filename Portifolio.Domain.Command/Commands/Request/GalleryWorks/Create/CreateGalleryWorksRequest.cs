using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create
{
    public class CreateGalleryWorksRequest : IRequest<Unit>
    {
        public int IdProjeto { get; private set; }
        public IEnumerable<IFormFile> Files { get; private set; }

        [JsonConstructor]
        public CreateGalleryWorksRequest(
            int idProjeto,
            IEnumerable<IFormFile> files)
        {
            IdProjeto = idProjeto;
            Files = files;
        }
    }
}
