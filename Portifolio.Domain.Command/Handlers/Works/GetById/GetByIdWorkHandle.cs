using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetById
{
    public class GetByIdWorkHandle : IRequestHandler<GetByIdWorksRequest, GetByIdWorksResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericQuery<Entities.Works, FilterWorksRequest> _dapper;

        public GetByIdWorkHandle(
            IMapper mapper,
            IGenericQuery<Entities.Works, FilterWorksRequest> dapper)
        {
            _mapper = mapper;
            _dapper = dapper;
        }
        public async Task<GetByIdWorksResponse> Handle(GetByIdWorksRequest request, CancellationToken cancellationToken)
        {
            GetByIdWorksResponse handleResponse = new GetByIdWorksResponse();


            var response = await _dapper.GetById(request.Id);
            if (response == null)
                throw new System.Exception("Registro não encontrado !");

            _mapper.Map<Entities.Works, GetByIdWorksResponse>(response, handleResponse);

            return handleResponse;
        }
    }
}
