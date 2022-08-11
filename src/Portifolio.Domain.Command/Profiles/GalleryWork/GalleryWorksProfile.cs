using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Command.Profiles.GalleryWork
{
    public sealed class GalleryWorksProfile : Profile
    {
        public GalleryWorksProfile()
        {
            CreateMap<GalleryWorks, FilterGalleryWorksResponse>();

            CreateMap<PatchGalleryWorksCommentRequest, GalleryWorks>();
        }
    }
}
