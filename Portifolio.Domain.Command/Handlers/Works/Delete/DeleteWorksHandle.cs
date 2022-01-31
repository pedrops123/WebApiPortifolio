using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Infrastructure.Database.EntityFramework.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Delete
{
    public class DeleteWorksHandle : IRequestHandler<DeleteWorksRequest, Unit>
    {
        private readonly WorksRepository _worksRepository;
        private IMapper _mapper;
        public DeleteWorksHandle(IMapper mapper)
        {
            _worksRepository = new WorksRepository();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWorksRequest request, CancellationToken cancellationToken)
        {
            var register = await _worksRepository.GetEntityById(request.Id);
            await _worksRepository.Delete(register);

            return Unit.Value;
        }
    }
}
