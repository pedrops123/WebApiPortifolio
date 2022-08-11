using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.Works.Update
{
    public class UpdateWorksRequest : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string ProjectName { get; set; }

        [JsonIgnore]
        public int? ImgThumbnailId { get; set; }

        public string DescriptionCover { get; set; }

        public string ProjectText { get; set; }

        [JsonIgnore]
        public int? UserUpdate { get; set; }

        [JsonIgnore]
        public DateTime? UdpatetDate { get; set; }
    }
}
