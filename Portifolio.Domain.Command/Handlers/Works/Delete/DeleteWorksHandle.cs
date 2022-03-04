using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Delete
{
    public class DeleteWorksHandle : IRequestHandler<DeleteWorksRequest, Unit>
    {
        private readonly IGeneric<Entities.Works> _repository;
        private IMapper _mapper;
        public DeleteWorksHandle(
            IMapper mapper,
            IGeneric<Entities.Works> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWorksRequest request, CancellationToken cancellationToken)
        {
            var register = await _repository.GetEntityById(request.Id);
            await _repository.Delete(register);

            return Unit.Value;
        }
    }
}
