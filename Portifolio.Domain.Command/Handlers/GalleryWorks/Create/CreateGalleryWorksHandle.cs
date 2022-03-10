using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
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

        private CreateGalleryWorksValidator _validator;
        public CreateGalleryWorksHandle(IMapper mapper,
            IMinIO minIOService)
        {
            _mapper = mapper;
            _minIOService = minIOService;
            _validator = new CreateGalleryWorksValidator();
        }

        public async Task<Unit> Handle(CreateGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            var validator = _validator.Validate(request);

            List<string> ListFiles = new List<string>();

            if (!validator.IsValid)
            {
                throw new ValidatorException(validator.Errors);
            }

            foreach (IFormFile file in request.Files)
            {
                ListFiles.Add(await _minIOService.UploadFiles(file));
            }

            return Unit.Value;
        }
    }
}
