using MediatR;
using Microsoft.AspNetCore.Http;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWork.Create
{
    public sealed class CreateGalleryWorksHandle : IRequestHandler<CreateGalleryWorksRequest, Unit>
    {
        private readonly IMinIO _minIOService;
        private readonly IGenericRepository<Works> _worksRepository;
        private readonly IGenericRepository<GalleryWorks> _repository;

        public CreateGalleryWorksHandle(
            IGenericRepository<Works> worksRepository,
            IGenericRepository<GalleryWorks> repository,
            IMinIO minIOService)
        {

            _worksRepository = worksRepository;
            _repository = repository;
            _minIOService = minIOService;
        }

        public async Task<Unit> Handle(CreateGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            var workResponse = await _worksRepository.GetEntityById(request.ProjectId);

            if (workResponse == null)
            {
                throw new ArgumentException("Id de projeto informado não existe no cadastro atual.", nameof(request.ProjectId));
            }

            foreach (IFormFile file in request.Files)
            {
                request.ListFiles.Add(await _minIOService.UploadFiles(file));
            }

            var registers = CreateListRegisters(request);

            await _repository.AddRange(registers);

            return Unit.Value;
        }

        private List<GalleryWorks> CreateListRegisters(CreateGalleryWorksRequest request)
        {
            List<GalleryWorks> listGallery = new List<GalleryWorks>();

            request.ListFiles.ForEach(r => listGallery.Add(new GalleryWorks(
                request.ProjectId, r)));

            return listGallery;
        }

    }
}
