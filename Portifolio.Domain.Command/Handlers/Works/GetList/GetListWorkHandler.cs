using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Query.Queries.Works;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetList
{
    public sealed class GetListWorkHandler : IRequestHandler<FilterWorksRequest, FilterWorksResponse>
    {
        public async  Task<FilterWorksResponse> Handle(FilterWorksRequest request, CancellationToken cancellationToken)
        {

            WorksQuery QueryDapper = new WorksQuery();
            var tesa = await QueryDapper.GetById(6);
            
            
            var teste = Task.FromResult(new FilterWorksResponse());
            return teste.Result;

        }
    }
}
