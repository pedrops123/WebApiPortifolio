using System;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetList
{
    public sealed class FilterWorksResponse
    {
        public int Id { get; set; }

        public string nome_projeto { get;  set; }

        public string img_thumbnail { get;  set; }

        public string descritivo_capa { get;  set; }

        public string texto_projeto { get;  set; }

        public int UserInsert { get;  set; }

        public DateTime InsertDate { get;  set; }

        public int? UserUpdate { get;  set; }

        public DateTime? UdpatetDate { get;  set; }
    }
}
