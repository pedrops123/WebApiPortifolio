using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.Delete;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Works.Delete
{
    public class DeleteWorksHandle : IRequestHandler<DeleteWorksRequest, Unit>
    {
        private readonly IGenericRepository<Entities.Works> _repository;
        private readonly IGenericRepository<Entities.GalleryWorks> _galleryRepository;
        private readonly IMinIO _minIOService;

        public DeleteWorksHandle(
            IMapper mapper,
            IMinIO minIOService,
            IGenericRepository<Entities.GalleryWorks> galleryRepository,
            IGenericRepository<Entities.Works> repository)
        {
            _galleryRepository = galleryRepository;
            _repository = repository;
            _minIOService = minIOService;
        }

        public async Task<Unit> Handle(DeleteWorksRequest request, CancellationToken cancellationToken)
        {
            var responseGallery = (await _galleryRepository.List()).Where(r => r.IdProjeto == request.Id).ToList();

            foreach (var photo in responseGallery)
            {
                await _minIOService.DeleteFile(photo.PathFile);
            }

            await _galleryRepository.RemoveRange(responseGallery);

            var register = await _repository.GetEntityById(request.Id);

            await _repository.Delete(register);

            return Unit.Value;
        }
    }
}
