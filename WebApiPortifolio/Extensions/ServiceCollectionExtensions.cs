using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Profiles.Works;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Infrastructure.Database.EntityFramework.Generics;
using Portifolio.Utils.MinIO;
using System.Linq;
using WebApiPortifolio.Controllers;

namespace WebApiPortifolio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateWorksRequest), typeof(WorksController));

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var profiles = typeof(WorksProfile).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            var mapperConfig = new MapperConfiguration(r =>
            {
                profiles.ToList().ForEach(p => r.AddProfile(p));
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMinIO, MinIOUtils>();
            services.AddTransient<IGeneric<Works>, RepositoryGenerics<Works>>();

            return services;
        }
    }
}
