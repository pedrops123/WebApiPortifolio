using AutoMapper;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.Update;
using Portifolio.Domain.Command.Commands.Response.Works.GetById;
using Portifolio.Domain.Command.Commands.Response.Works.GetList;

namespace Portifolio.Domain.Command.Profiles.Works
{
    public sealed class WorkProfile : Profile
    {
        public WorkProfile()
        {
            // Create Mapper Work
            CreateMap<CreateWorkRequest, Entities.Works>();

            // Update mapper work
            CreateMap<UpdateWorkRequest, Entities.Works>();

            // Get List Mapper work
            CreateMap<Entities.Works, FilterWorksResponse>();

            // Get By Id mapper work
            CreateMap<Entities.Works, GetByIdWorksResponse>();
        }
    }
}
