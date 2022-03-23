using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetList
{
    public sealed class GetListWorkHandle : IRequestHandler<FilterWorksRequest, IEnumerable<FilterWorksResponse>>
    {
        private IMapper _mapper;
        private readonly IMinIO _minIOService;
        private readonly IGenericQuery<Entities.Works, Portifolio.Domain.Query.Repositories.Works.Filters.FilterWorksRequest> _dapper;
        public GetListWorkHandle(
              IMapper mapper,
              IMinIO minIOService,
              IGenericQuery<Entities.Works, Portifolio.Domain.Query.Repositories.Works.Filters.FilterWorksRequest> dapper)
        {
            _mapper = mapper;
            _minIOService = minIOService;
            _dapper = dapper;
        }

        public async Task<IEnumerable<FilterWorksResponse>> Handle(FilterWorksRequest request, CancellationToken cancellationToken)
        {
            var responseQuery = await _dapper.GetList(new Query.Repositories.Works.Filters.FilterWorksRequest()
            {
                nome_projeto = request.nome_projeto,
                descritivo_capa = request.descritivo_capa,
                texto_projeto = request.texto_projeto
            });

            List<FilterWorksResponse> response = _mapper.Map<List<Entities.Works>, List<FilterWorksResponse>>(responseQuery);

            foreach (FilterWorksResponse works in response)
            {
                if (works.img_thumbnail != null)
                {
                    works.img_thumbnail.UrlFile = await _minIOService.GetFile(works.img_thumbnail.PathFile);
                }
            }

            return response;
        }
    }
}