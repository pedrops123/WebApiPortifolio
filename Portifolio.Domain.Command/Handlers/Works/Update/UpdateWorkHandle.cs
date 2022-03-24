using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Update
{
    public class UpdateWorkHandle : IRequestHandler<UpdateWorksRequest, Unit>
    {
        private readonly IGenericRepository<Entities.Works> _repository;
        private IMapper _mapper;

        public UpdateWorkHandle(
            IMapper mapper,
            IGenericRepository<Entities.Works> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorksRequest request, CancellationToken cancellationToken)
        {
            var register = await _repository.GetEntityById(request.Id);

            _mapper.Map(request, register);

            await _repository.Update(register);

            return Unit.Value;
        }
    }
}
