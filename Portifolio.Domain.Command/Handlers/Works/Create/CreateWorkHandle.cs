using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Infrastructure.Database.EntityFramework.Repositories.Works;
using Portifolio.Utils.CustomExceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorksRequest, Unit>
    {
        private readonly WorksRepository _worksRepository;
        private IMapper _mapper;
        private CreateWorkValidator _validator;

        public CreateWorkHandle(
            IMapper mapper)
        {
            _worksRepository = new WorksRepository();
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
            await _worksRepository.Add(Work);
            return Unit.Value;
        }
    }
}
