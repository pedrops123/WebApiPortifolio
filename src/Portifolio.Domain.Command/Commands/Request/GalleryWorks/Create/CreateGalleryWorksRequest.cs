using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create
{
    public sealed class CreateGalleryWorksRequest : IRequest<Unit>
    {
        public int ProjectId { get; private set; }

        public IFormFileCollection Files { get; private set; }

        [JsonIgnore]
        public List<string> ListFiles { get; set; } = new List<string>();

        [JsonConstructor]
        public CreateGalleryWorksRequest(
            int projectId,
            IFormFileCollection files)
        {
            ProjectId = projectId;
            Files = files;
        }
    }
}
