using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Utils.CustomExceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.Create
{
    public sealed class CreateGalleryWorksHandle : IRequestHandler<CreateGalleryWorksRequest, Unit>
    {
        private IMapper _mapper;
        private IMinIO _minIOService;
        IGenericRepository<Entities.GalleryWorks> _repository;

        private CreateGalleryWorksValidator _validator;
        public CreateGalleryWorksHandle(IMapper mapper,
            IGenericRepository<Entities.GalleryWorks> repository,
            IMinIO minIOService)
        {
            _mapper = mapper;
            _repository = repository;
            _minIOService = minIOService;
            _validator = new CreateGalleryWorksValidator();
        }

        public async Task<Unit> Handle(CreateGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            var validator = _validator.Validate(request);

            if (!validator.IsValid)
            {
                throw new ValidatorException(validator.Errors);
            }

            foreach (IFormFile file in request.Files)
            {
                request.ListFiles.Add(await _minIOService.UploadFiles(file));
            }

            var registers = CreateListRegisters(request);

            await _repository.AddRange(registers);

            return Unit.Value;
        }

        private List<Entities.GalleryWorks> CreateListRegisters(CreateGalleryWorksRequest request)
        {
            List<Entities.GalleryWorks> listGallery = new List<Entities.GalleryWorks>();

            request.ListFiles.ForEach(r => listGallery.Add(new Entities.GalleryWorks(
                request.IdProjeto, r)));

            return listGallery;
        }

    }
}
