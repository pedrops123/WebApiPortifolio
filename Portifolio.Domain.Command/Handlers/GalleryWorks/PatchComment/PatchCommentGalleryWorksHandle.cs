using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment;
using Portifolio.Domain.Generics;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.PatchComment
{
    public sealed class PatchCommentGalleryWorksHandle : IRequestHandler<PatchGalleryWorksCommentRequest, Unit>
    {
        private readonly IGenericRepository<Entities.GalleryWorks> _repository;
        private readonly IMapper _mapper;

        public PatchCommentGalleryWorksHandle(
            IGenericRepository<Entities.GalleryWorks> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchGalleryWorksCommentRequest request, CancellationToken cancellationToken)
        {
            var register = await _repository.GetEntityById(request.Id);

            _mapper.Map(request, register);

            await _repository.Update(register);

            return Unit.Value;
        }
    }
}
