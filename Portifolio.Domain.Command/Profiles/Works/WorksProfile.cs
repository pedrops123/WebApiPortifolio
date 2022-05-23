using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.PatchThumbnail;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;

namespace Portifolio.Domain.Command.Profiles.Works
{
    public sealed class WorksProfile : Profile
    {
        public WorksProfile()
        {
            CreateMap<CreateWorksRequest, Entities.Works>();

            CreateMap<UpdateWorksRequest, Entities.Works>();

            CreateMap<Entities.Works, FilterWorksResponse>();

            CreateMap<Entities.Works, GetByIdWorksResponse>();

            CreateMap<PatchThumbnailWorksRequest, Entities.Works>();
        }
    }
}
