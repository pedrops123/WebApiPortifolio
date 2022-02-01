using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Portifolio.Domain.Command.Commands.Request.Works.Create
{
    public sealed class CreateWorksRequest : IRequest<Unit>
    {
        public string nome_projeto { get; set; }

        public string img_thumbnail { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }

        [JsonIgnore]
        public DateTime InsertDate { get; set; }

        [JsonIgnore]
        public int UserInsert { get; set; }
    }
}
