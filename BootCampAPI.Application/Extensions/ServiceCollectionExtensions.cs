using BootCampAPI.Application.Behaviors;
using BootCampAPI.Application.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BootCampAPI.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AddAppSettings(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>))
                    .AddScoped<UnitOfWorkBehaviorState>();

            return services;
        }

        private static void AddAppSettings(IServiceCollection services)
        {
            // Add your app settings configuration here
        }
    }
}