using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.GetById;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Work.GetById
{
    public sealed class GetByIdWorkHandle : IRequestHandler<GetByIdWorksRequest, GetByIdWorksResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMinIO _minIOService;
        private readonly IGenericQuery<GalleryWorks, FilterGalleryWorksRequest> _dapperGalleryWorks;
        private readonly IGenericQuery<Works, FilterWorksRequest> _dapper;

        public GetByIdWorkHandle(
            IMapper mapper,
            IMinIO minIOService,
            IGenericQuery<GalleryWorks, FilterGalleryWorksRequest> dapperGalleryWorks,
            IGenericQuery<Works, FilterWorksRequest> dapper)
        {
            _mapper = mapper;
            _dapper = dapper;
            _dapperGalleryWorks = dapperGalleryWorks;
            _minIOService = minIOService;
        }

        public async Task<GetByIdWorksResponse> Handle(GetByIdWorksRequest request, CancellationToken cancellationToken)
        {
            GetByIdWorksResponse handleResponse = new GetByIdWorksResponse();

            var response = await _dapper.GetById(request.Id);

            if (response == null)
                throw new System.Exception("Registro não encontrado !");

            _mapper.Map<Works, GetByIdWorksResponse>(response, handleResponse);

            var responseFotos = await _dapperGalleryWorks.GetList(new FilterGalleryWorksRequest(request.Id));

            handleResponse.Photos = _mapper.Map<List<GalleryWorks>, List<FilterGalleryWorksResponse>>(responseFotos);

            foreach (FilterGalleryWorksResponse foto in handleResponse.Photos)
            {
                foto.UrlFile = await _minIOService.GetFile(foto.PathFile);
            }

            if (handleResponse.ImgThumbnailId != null)
            {
                handleResponse.img_thumbnail = handleResponse.Photos.Where(r => r.Id == handleResponse.ImgThumbnailId).FirstOrDefault();
            }

            return handleResponse;
        }
    }
}