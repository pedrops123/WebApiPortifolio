using System;

namespace Portifolio.Domain.Command.Commands.Response.Works.GetList
{
    public sealed class FilterWorksResponse
    {
        public int Id { get; set; }
        public string nome_projeto { get; private set; }
        public string img_thumbnail { get; private set; }
        public string descritivo_capa { get; private set; }
        public string texto_projeto { get; private set; }
        public int UserInsert { get; private set; }
        public DateTime InsertDate { get; private set; }
        public int? UserUpdate { get; private set; }
        public DateTime? UdpatetDate { get; private set; }
    }
}
