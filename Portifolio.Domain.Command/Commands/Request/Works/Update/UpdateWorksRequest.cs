using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Commands.Request.Works.Update
{
    public class UpdateWorksRequest : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string nome_projeto { get; set; }

        public string img_thumbnail { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }

        [JsonIgnore]
        public int? UserUpdate { get; set; }

        [JsonIgnore]
        public DateTime? UdpatetDate { get; set; }
    }
}
