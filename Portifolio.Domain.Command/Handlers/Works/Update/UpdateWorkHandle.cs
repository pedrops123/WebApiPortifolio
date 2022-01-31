using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Infrastructure.Database.EntityFramework.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Update
{
    public class UpdateWorkHandle : IRequestHandler<UpdateWorkRequest, Unit>
    {
        private readonly WorksRepository _worksRepository;
        private IMapper _mapper;
        public UpdateWorkHandle(IMapper mapper)
        {
            _worksRepository = new WorksRepository();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkRequest request, CancellationToken cancellationToken)
        {
            var register = await _worksRepository.GetEntityById(request.Id);

            _mapper.Map(request, register);

            await _worksRepository.Update(register);

            return Unit.Value;
        }
    }
}
