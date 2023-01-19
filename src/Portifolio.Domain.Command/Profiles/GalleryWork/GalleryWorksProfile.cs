using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.Create;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.PatchComment;
using Portifolio.Domain.Command.Commands.Response.GalleryWorks.GetList;
using Portifolio.Domain.Entities;
using System.Collections.Generic;

namespace Portifolio.Domain.Command.Profiles.GalleryWork
{
    public sealed class GalleryWorksProfile : Profile
    {
        public GalleryWorksProfile()
        {
            CreateMap<CreateGalleryWorksRequest, List<GalleryWorks>>().BeforeMap((src, dest) =>
            {
                src.ListFiles.ForEach(r => dest.Add(new GalleryWorks(src.ProjectId, r)));
            });

            CreateMap<GalleryWorks, FilterGalleryWorksResponse>();

            CreateMap<PatchGalleryWorksCommentRequest, GalleryWorks>();
        }
    }
}
