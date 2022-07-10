using CulinaryRecipes.Aplication.Extensions;
using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Infrastucture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryRecipes.Infrastucture.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services)
        {
            services.AddAplicationConfigureServices();
            services.AddElasticClient();
            services.AddSingleton<ISearchService, SearchService>();
            return services;
        }
    }
}
