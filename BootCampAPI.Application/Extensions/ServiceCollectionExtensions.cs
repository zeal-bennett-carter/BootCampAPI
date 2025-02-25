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

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

        private static void AddAppSettings(IServiceCollection services)
        {
            // Add your app settings configuration here
        }
    }
}