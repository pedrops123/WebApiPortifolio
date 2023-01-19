using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Portifolio.Domain.Command.Commands.Request.Works.Create;
using Portifolio.Domain.Command.Handlers.Work.Create;
using Portifolio.Domain.Command.Profiles.Work;
using Portifolio.Domain.Generics;
using Portifolio.Domain.ITextSharp;
using Portifolio.Domain.MinIO;
using Portifolio.Domain.Query.Configurations;
using Portifolio.Infrastructure.Database.EntityFramework.Generics;
using Portifolio.Utils.ITextSharpResumeUtils;
using Portifolio.Utils.MinIO;
using Portifolio.WebApi.Controllers;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            var location = Assembly.GetAssembly(typeof(Startup)).Location;
            var pathXml = Path.Combine(location.Substring(0, location.IndexOf(Assembly.GetAssembly(typeof(Startup)).ManifestModule.Name)), string.Format("{0}.xml", typeof(Startup).GetTypeInfo().Assembly.GetName().Name));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portifolio.WebApi", Version = "v1" });
                c.IncludeXmlComments(pathXml);
            });

            return services;
        }
    }
}