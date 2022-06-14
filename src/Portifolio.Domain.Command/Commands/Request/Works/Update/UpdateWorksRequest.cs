using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.Works.Update
{
    public class UpdateWorksRequest : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string nome_projeto { get; set; }

        [JsonIgnore]
        public int? img_thumbnail_id { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }

        [JsonIgnore]
        public int? UserUpdate { get; set; }

        [JsonIgnore]
        public DateTime? UdpatetDate { get; set; }
    }
}
