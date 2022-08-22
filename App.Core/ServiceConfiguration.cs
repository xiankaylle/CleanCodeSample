using App.Core.Behaviours;
using App.Core.Contracts;
using App.Core.CustomerService.Commands;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Core
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            //Mapster Confgiguration
            var typeAdapterConfig = new TypeAdapterConfig();
            // scans the assembly and gets the IRegister
            var mappingRegistrations = TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            // adds the registration to the TypeAdapterConfig
            mappingRegistrations.ToList().ForEach(register => register.Register(typeAdapterConfig));
            // register the mapper as Singleton service for this application
            var mapperConfig = new Mapper(typeAdapterConfig);

            services.AddSingleton<IMapper>(mapperConfig);

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            var applicationAssembly = typeof(AssemblyReference).Assembly;

            services.AddMediatR(applicationAssembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            /*
              To enable .Scan install
              dotnet add package Scrutor --version 4.2.0
              ===================================================
              What is Scrutor?
              Scrutor is an open source library that adds assembly scanning capabilities to the ASP.Net Core DI container
            */
            services.Scan(scan => scan
                           .FromApplicationDependencies()
                           .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                           .AsImplementedInterfaces()
                           .WithTransientLifetime());


            return services;
        }
    }
}
