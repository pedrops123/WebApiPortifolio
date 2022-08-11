using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Work.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorksRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Works> _repository;

        public CreateWorkHandle(
            IGenericRepository<Works> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWorksRequest request, CancellationToken cancellationToken)
        {
            var work = _mapper.Map<CreateWorksRequest, Works>(request);
            await _repository.Add(work);

            return Unit.Value;
        }
    }
}
