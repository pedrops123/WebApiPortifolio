using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.Works.Create
{
    public sealed class CreateWorksRequest : IRequest<Unit>
    {
        public string ProjectName { get; set; }

        [JsonIgnore]
        public int? ImgThumbnailId { get; set; }

        public string DescriptionCover { get; set; }

        public string ProjectText { get; set; }

        [JsonIgnore]
        public DateTime InsertDate { get; set; }

        [JsonIgnore]
        public int UserInsert { get; set; }
    }
}
