using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Generics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetList
{
    public sealed class GetListWorkHandle : IRequestHandler<FilterWorksRequest, List<FilterWorksResponse>>
    {
        private IMapper _mapper;
        private readonly IGenericQuery<Entities.Works, FilterWorksRequest> _dapper;
        public GetListWorkHandle(
              IMapper mapper,
              IGenericQuery<Entities.Works, FilterWorksRequest> dapper)
        {
            _mapper = mapper;
            _dapper = dapper;
        }

        public async Task<List<FilterWorksResponse>> Handle(FilterWorksRequest request, CancellationToken cancellationToken)
        {
            var teste = await _dapper.GetList(request);

            List<FilterWorksResponse> response = _mapper.Map<List<Entities.Works>, List<FilterWorksResponse>>(teste);

            return response;
        }
    }
}
