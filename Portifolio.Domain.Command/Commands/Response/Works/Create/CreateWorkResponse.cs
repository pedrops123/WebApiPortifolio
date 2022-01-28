using System;

namespace Portifolio.Domain.Command.Commands.Response.Works.Create
{
    public class CreateWorkResponse
    {
        public string nome_projeto { get; set; }

        public string img_thumbnail { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }

        public DateTime InsertDate { get; set; }

        public int UserInsert { get; set; }
    }
}
