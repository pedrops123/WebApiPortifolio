using AutoMapper;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;

namespace Portifolio.Domain.Command.Profiles.GalleryWorks
{
    public sealed class GalleryWorksProfile : Profile
    {
        public GalleryWorksProfile()
        {
            CreateMap<Entities.GalleryWorks, FilterGalleryWorksResponse>();
            //CreateMap<CreateGalleryWorksRequest, List<Entities.GalleryWorks>>().ForMember(r, opt => opt.MapFrom(src=>src.));
        }
    }
}
