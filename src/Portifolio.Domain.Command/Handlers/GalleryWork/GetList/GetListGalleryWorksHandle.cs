using AutoMapper;
using MediatR;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Portifolio.Domain.Command.Handlers.GalleryWork.GetList
{
    public sealed class GetListGalleryWorksHandle : IRequestHandler<FilterGalleryWorksRequest, IEnumerable<FilterGalleryWorksResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericQuery<GalleryWorks, FilterGalleryWorksRequest> _dapper;

        public GetListGalleryWorksHandle(
            IMapper mapper,
            IGenericQuery<Entities.GalleryWorks, FilterGalleryWorksRequest> dapper)
        {
            _dapper = dapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilterGalleryWorksResponse>> Handle(FilterGalleryWorksRequest request, CancellationToken cancellationToken)
        {
            List<FilterGalleryWorksResponse> response = new List<FilterGalleryWorksResponse>();

            var responseList = await _dapper.GetList(request);

            _mapper.Map(responseList, response);

            return response;
        }
    }
}
