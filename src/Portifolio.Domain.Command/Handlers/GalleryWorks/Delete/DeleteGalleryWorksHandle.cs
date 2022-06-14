using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Delete;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.Delete
{
    public sealed class DeleteGalleryWorksHandle : IRequestHandler<DeleteGalleryWorksRequest, Unit>
    {
        private readonly IGenericRepository<Entities.GalleryWorks> _repository;
        private readonly IMinIO _minIOrepository;

        public DeleteGalleryWorksHandle(
            IGenericRepository<Entities.GalleryWorks> repository,
            IMinIO minIOrepository)
        {
            _repository = repository;
            _minIOrepository = minIOrepository;
        }

        public async Task<Unit> Handle(DeleteGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetEntityById(request.Id);

            if (response == null)
            {
                throw new ArgumentException("Registro nao existe na base de dados.", nameof(request.Id));
            }

            await _minIOrepository.DeleteFile(response.PathFile);

            await _repository.Delete(response);

            return Unit.Value;
        }
    }
}