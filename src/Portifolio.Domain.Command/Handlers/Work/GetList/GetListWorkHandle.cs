using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.Work.GetList
{
    public sealed class GetListWorkHandle : IRequestHandler<FilterWorksRequest, IEnumerable<FilterWorksResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMinIO _minIOService;
        private readonly IGenericQuery<Works, FilterWorksRequest> _dapper;
        private readonly IGenericQuery<GalleryWorks, FilterGalleryWorksRequest> _dapperGalleryWorks;

        public GetListWorkHandle(
              IMapper mapper,
              IMinIO minIOService,
              IGenericQuery<GalleryWorks, FilterGalleryWorksRequest> dapperGalleryWorks,
              IGenericQuery<Works, FilterWorksRequest> dapper)
        {
            _mapper = mapper;
            _minIOService = minIOService;
            _dapperGalleryWorks = dapperGalleryWorks;
            _dapper = dapper;
        }

        public async Task<IEnumerable<FilterWorksResponse>> Handle(FilterWorksRequest request, CancellationToken cancellationToken)
        {
            var responseQuery = await _dapper.GetList(request);

            List<FilterWorksResponse> response = _mapper.Map<List<Works>, List<FilterWorksResponse>>(responseQuery);

            foreach (FilterWorksResponse works in response)
            {
                if (works.ImgThumbnailId != null)
                {
                    var responseGallery = await _dapperGalleryWorks.GetById((int)works.ImgThumbnailId);

                    FilterGalleryWorksResponse galleryResponse = _mapper.Map<GalleryWorks, FilterGalleryWorksResponse>(responseGallery);

                    if (responseGallery != null)
                    {
                        galleryResponse.UrlFile = await _minIOService.GetFile(responseGallery.PathFile);
                        works.img_thumbnail = galleryResponse;
                    }
                }
            }

            return response;
        }
    }
}