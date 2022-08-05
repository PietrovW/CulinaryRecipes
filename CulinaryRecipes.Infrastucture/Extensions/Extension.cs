using CulinaryRecipes.Aplication.Extensions;
using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Infrastucture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryRecipes.Infrastucture.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAplicationConfigureServices();
            services.AddElasticClient(configuration);
            services.AddSingleton<ISearchService, SearchService>();
            return services;
        }
    }
}
