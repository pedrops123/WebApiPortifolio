using MediatR;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.Works.GetList
{
    public sealed class FilterWorksRequest : IRequest<IEnumerable<FilterWorksResponse>>
    {
        public string nome_projeto { get; set; }

        public string descritivo_capa { get; set; }

        public string texto_projeto { get; set; }
    }
}
