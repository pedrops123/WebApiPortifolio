using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWorks.Create
{
    public sealed class CreateGalleryWorksHandle : IRequestHandler<CreateGalleryWorksRequest, Unit>
    {
        private IMapper _mapper;
        private CreateGalleryWorksValidator _validator;
        public CreateGalleryWorksHandle(IMapper mapper)
        {
            _mapper = mapper;
            _validator = new CreateGalleryWorksValidator();
        }

        public async Task<Unit> Handle(CreateGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            var validator = _validator.Validate(request);

            if (!validator.IsValid)
            {
                List<string> Errors = new List<string>();
                validator.Errors.ForEach(r => Errors.Add(r.ErrorMessage));
            }

            return Unit.Value;
        }
    }
}
