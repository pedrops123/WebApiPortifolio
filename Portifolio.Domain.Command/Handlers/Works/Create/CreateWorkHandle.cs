using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Infrastructure.Database.EntityFramework.Repositories;
using Portifolio.Utils.CustomExceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Create
{
    public sealed class CreateWorkHandle : IRequestHandler<CreateWorksRequest, Unit>
    {
        private readonly WorksRepository _worksRepository;
        private IMapper _mapper;

        public CreateWorkHandle(
            IMapper mapper)
        {
            _worksRepository = new WorksRepository();
            _mapper = mapper;

        }

        public async Task<Unit> Handle(CreateWorksRequest request, CancellationToken cancellationToken)
        {
            CreateWorkValidator _validator = new CreateWorkValidator();
            var validator = _validator.Validate(request);
            if (!validator.IsValid)
            {
                List<string> Errors = new List<string>();
                validator.Errors.ForEach(r => Errors.Add(r.ErrorMessage));

                throw new ValidatorException(Errors);
            }

            var Work = _mapper.Map<CreateWorksRequest, Entities.Works>(request);
            await _worksRepository.Add(Work);
            return Unit.Value;
        }
    }
}
