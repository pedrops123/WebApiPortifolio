using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;
using Portifolio.Domain.Entities;

namespace Portifolio.Domain.Command.Profiles.Work
{
    public sealed class WorksProfile : Profile
    {
        public WorksProfile()
        {
            CreateMap<CreateWorksRequest, Works>();

            CreateMap<UpdateWorksRequest, Works>();

            CreateMap<Works, FilterWorksResponse>();

            CreateMap<Works, GetByIdWorksResponse>();

            CreateMap<PatchThumbnailWorksRequest, Works>();
        }
    }
}
