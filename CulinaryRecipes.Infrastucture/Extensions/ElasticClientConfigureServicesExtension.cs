using CulinaryRecipes.Shared.Domen;
using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace CulinaryRecipes.Infrastucture.Extensions
{
    internal static class ElasticClientServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticClient(this IServiceCollection services)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var settings = new ConnectionSettings(pool)
                .DefaultIndex("recipes");
            var client = new ElasticClient(settings);
            services.AddSingleton(client);

            return services;
        }
    }
}
