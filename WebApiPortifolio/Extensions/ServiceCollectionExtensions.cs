using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Profiles.Works;
using WebApiPortifolio.Controllers;

namespace WebApiPortifolio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateWorkRequest), typeof(WorksController));
            var mapperConfig = new MapperConfiguration(r => {
                r.AddProfile(new WorkProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
