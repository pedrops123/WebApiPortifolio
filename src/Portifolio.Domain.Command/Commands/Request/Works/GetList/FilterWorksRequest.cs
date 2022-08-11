using MediatR;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Commands.Request.Works.GetList
{
    public sealed class FilterWorksRequest : IRequest<IEnumerable<FilterWorksResponse>>
    {
        public string ProjectName { get; set; }

        public string DescriptionCover { get; set; }

        public string ProjectText { get; set; }
    }
}
