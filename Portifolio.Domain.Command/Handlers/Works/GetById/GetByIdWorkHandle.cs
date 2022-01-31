using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Query.Queries.Works;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.GetById
{
    public class GetByIdWorkHandle : IRequestHandler<GetByIdWorksRequest, GetByIdWorksResponse>
    {
        private readonly IMapper _mapper;

        public GetByIdWorkHandle(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<GetByIdWorksResponse> Handle(GetByIdWorksRequest request, CancellationToken cancellationToken)
        {
            GetByIdWorksResponse handleResponse = new GetByIdWorksResponse();
            WorksQuery QueryDapper = new WorksQuery();

            var response = await QueryDapper.GetById(request.Id);
            if (response == null)
                throw new System.Exception("Registro não encontrado !");
           
            _mapper.Map<Entities.Works, GetByIdWorksResponse>(response,handleResponse);

            return handleResponse;
        }
    }
}
