using CulinaryRecipes.Shared.Domen;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace CulinaryRecipes.Infrastucture.Extensions
{
    internal static class ElasticClientServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticClient(this IServiceCollection services,IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:Uri"];
            var defaultIndex = configuration["ELKConfiguration:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            //  var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            // var settings = new ConnectionSettings(pool)
            //   .DefaultIndex("books");

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);

            return services;
        }
        private static void AddDefaultMappings(ConnectionSettings settings)
        {
           // settings.DefaultMappingFor<Recipe>();// p =>
                       // p.Ignore(x => x.)
                            //.Ignore(x => x.Id)
                          //  .Ignore(x => x.Quantity));
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            client.Indices.Create(indexName, i => i.Map<Recipe>(x => x.AutoMap()));
        }
    }
}
