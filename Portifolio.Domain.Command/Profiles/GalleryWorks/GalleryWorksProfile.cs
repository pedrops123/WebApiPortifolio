using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Profiles.GalleryWorks
{
    public sealed class GalleryWorksProfile : Profile
    {
        public GalleryWorksProfile()
        {
            CreateMap<CreateGalleryWorksRequest, List<Entities.GalleryWorks>>();
        }
    }
}
