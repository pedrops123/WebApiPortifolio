using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Generics;
using Portifolio.Utils.CustomExceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorksRequest, Unit>
    {
        private IMapper _mapper;
        private IGenericRepository<Entities.Works> _repository;
        private CreateWorkValidator _validator;

        public CreateWorkHandle(
            IGenericRepository<Entities.Works> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new CreateWorkValidator();
        }

        public async Task<Unit> Handle(CreateWorksRequest request, CancellationToken cancellationToken)
        {
            var validator = _validator.Validate(request);

            if (!validator.IsValid)
            {
                throw new ValidatorException(validator.Errors);
            }

            var Work = _mapper.Map<CreateWorksRequest, Entities.Works>(request);
            await _repository.Add(Work);

            return Unit.Value;
        }
    }
}
