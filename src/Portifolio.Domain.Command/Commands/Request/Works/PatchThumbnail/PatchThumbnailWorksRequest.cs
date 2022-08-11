using MediatR;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail
{
    public sealed class PatchThumbnailWorksRequest : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int ImgThumbnailId { get; set; }
    }
}
