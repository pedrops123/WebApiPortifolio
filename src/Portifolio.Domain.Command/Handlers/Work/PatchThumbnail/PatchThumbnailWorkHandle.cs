using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Work.PatchThumbnail
{
    public sealed class PatchThumbnailWorkHandle : IRequestHandler<PatchThumbnailWorksRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Works> _repository;
        private readonly IGenericRepository<GalleryWorks> _repositoryGallery;

        public PatchThumbnailWorkHandle(
            IMapper mapper,
            IGenericRepository<GalleryWorks> repositoryGallery,
            IGenericRepository<Works> repository)
        {
            _mapper = mapper;
            _repositoryGallery = repositoryGallery;
            _repository = repository;
        }

        public async Task<Unit> Handle(PatchThumbnailWorksRequest request, CancellationToken cancellationToken)
        {
            var responseGallery = await _repositoryGallery.GetEntityById(request.ImgThumbnailId);

            if (responseGallery == null)
            {
                throw new ArgumentException("Foto não existe no cadastro ! Favor verificar se a mesma ainda existe no cadastro ou foi deletado !", nameof(request.ImgThumbnailId));
            }

            var response = await _repository.GetEntityById(request.Id);

            if (response == null)
            {
                throw new ArgumentException("Projeto não existe no cadastro ! Favor verificar se a mesma ainda existe no cadastro ou foi deletado ! ", nameof(request.Id));
            }

            _mapper.Map(request, response);

            await _repository.Update(response);

            return Unit.Value;
        }
    }
}