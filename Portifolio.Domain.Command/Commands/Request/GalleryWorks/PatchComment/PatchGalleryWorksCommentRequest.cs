using MediatR;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment
{
    public sealed class PatchGalleryWorksCommentRequest : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Comment { get; set; }
    }
}
