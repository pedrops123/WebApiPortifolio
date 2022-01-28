using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Query.Queries.Works;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetList
{
    public sealed class GetListWorkHandler : IRequestHandler<FilterWorksRequest, List<FilterWorksResponse>>
    {
        private IMapper _mapper;

        public GetListWorkHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<FilterWorksResponse>> Handle(FilterWorksRequest request, CancellationToken cancellationToken)
        {
            WorksQuery QueryDapper = new WorksQuery();
            var teste = await QueryDapper.GetList(new Query.Queries.Works.Filters.FilterWorksRequest()
            {
                descritivo_capa = request.descritivo_capa,
                nome_projeto = request.nome_projeto,
                texto_projeto = request.texto_projeto
            });

            List<FilterWorksResponse> response = _mapper.Map<List<Entities.Works>, List<FilterWorksResponse>>(teste);

            return response;
        }
    }
}
