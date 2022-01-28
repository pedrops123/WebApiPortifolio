using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Response.Works.Create;
using Portifolio.Infrastructure.Database.EntityFramework.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorkRequest, CreateWorkResponse> 
    {
        private readonly WorksRepository _worksRepository;
        private IMapper _mapper;

        public CreateWorkHandle(IMapper mapper)
        {
            _worksRepository = new WorksRepository();
            _mapper = mapper;
        }

        public async Task<CreateWorkResponse> Handle(CreateWorkRequest request, CancellationToken cancellationToken)
        {
            var Work = _mapper.Map<CreateWorkRequest, Entities.Works>(request);
            var RetornoObjeto = await _worksRepository.Add(Work);
            CreateWorkResponse response = _mapper.Map<Entities.Works, CreateWorkResponse>(RetornoObjeto);


            return response;
        }
    }
}
