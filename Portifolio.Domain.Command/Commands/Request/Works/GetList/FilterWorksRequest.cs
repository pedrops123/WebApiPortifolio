using MediatR;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;


namespace Portifolio.Domain.Command.Commands.Request.Works.GetList
{
    public sealed class FilterWorksRequest : IRequest<FilterWorksResponse>
    {
        public string ProjectName { get;  set; }
        public string ProjectText { get;  set; }
    }
}
