using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorksRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Entities.Works> _repository;

        public CreateWorkHandle(
            IGenericRepository<Entities.Works> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWorksRequest request, CancellationToken cancellationToken)
        {
            var work = _mapper.Map<CreateWorksRequest, Entities.Works>(request);
            await _repository.Add(work);

            return Unit.Value;
        }
    }
}
