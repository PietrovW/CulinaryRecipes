using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CulinaryRecipes.Aplication.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddAplicationConfigureServices(this IServiceCollection services)
        {
            Assembly[] assemblie = new Assembly[] { typeof(Extension).GetTypeInfo().Assembly };
            services.AddMediator(cfg =>
            {
                cfg.AddConsumers(assemblie);
            });
            return services;
        }
    }
}
