using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Command.Commands.Request.GalleryWorks.GetList;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Commands.Request.Works.GetList;
using Portifolio.Domain.Command.Profiles.Works;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Generics;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Query.Configurations;
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

        public static IServiceCollection AddGeneralServices(this IServiceCollection services)
        {
            services.AddTransient<IMinIO, MinIOUtils>();

            return services;
        }

        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            services
                  .AddTransient<IGenericQuery<GalleryWorks, FilterGalleryWorksRequest>, DapperCustomSearch<GalleryWorks, FilterGalleryWorksRequest>>()
                  .AddTransient<IGenericQuery<Works, FilterWorksRequest>, DapperCustomSearch<Works, FilterWorksRequest>>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services
                .AddTransient<IGenericRepository<Works>, RepositoryGenerics<Works>>()
                .AddTransient<IGenericRepository<GalleryWorks>, RepositoryGenerics<GalleryWorks>>();

            return services;
        }
    }
}
