using System.Linq;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Handlers.Works.Create;
using Portifolio.Domain.Command.Profiles.Works;
using Portifolio.Domain.Generics;
using Portifolio.Domain.ITextSharp;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Query.Configurations;
using Portifolio.Infrastructure.Database.EntityFramework.Generics;
using Portifolio.Utils.ITextSharpResumeUtils;
using Portifolio.Utils.MinIO;
using Portifolio.WebApi.Controllers;

namespace Portifolio.WebApi.Extensions
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
            services
                .AddTransient<ITextSharpUtils, ServicePDFResume>()
                .AddTransient<IMinIO, MinIOUtils>();

            return services;
        }
   
        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            services
                 .AddTransient(typeof(IGenericQuery<,>), typeof(DapperDefaultSearch<,>));
                
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IGenericRepository<>), typeof(RepositoryGenerics<>));

            return services;
        }

        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(r =>
            {
                r.RegisterValidatorsFromAssembly(typeof(CreateWorkValidator).Assembly);
            });

            return services;
        }
    }
}
