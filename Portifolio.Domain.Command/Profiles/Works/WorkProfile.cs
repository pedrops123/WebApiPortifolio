using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Response.Works.Create;

namespace Portifolio.Domain.Command.Profiles.Works
{
    public sealed class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<CreateWorkRequest, Entities.Works>();
            CreateMap<Entities.Works, CreateWorkResponse>();
        }
    }
}
