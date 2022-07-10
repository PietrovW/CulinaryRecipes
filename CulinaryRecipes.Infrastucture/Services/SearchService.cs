using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Shared.Domen;
using Microsoft.Extensions.Logging;
using Nest;

namespace CulinaryRecipes.Infrastucture.Services
{
    internal class SearchService : ISearchService
    {
        private readonly ILogger<SearchService> _logger;
        private readonly ElasticClient _elasticClient;

        public SearchService(ILogger<SearchService> logger, ElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
        }
        public async Task<IReadOnlyCollection<Recipe>> FindAsync(string query, int page = 1, int pageSize = 5)
        {
            var response = await _elasticClient.SearchAsync<Recipe>(s => s.Query(q => q.QueryString(d => d.Query(query)))
          .From((page - 1) * pageSize)
          .Size(pageSize));

            if (!response.IsValid)
            {
                return new Recipe[] { };
            }
            return response.Documents;
        }

        public async Task<IReadOnlyCollection<Recipe>> NumberAllergensFindAsync(string query, int page = 1, int pageSize = 5)
        {
            var response = await _elasticClient.SearchAsync<Recipe>(s => s.Query(q => q.Term(t => t
                    .Field(f => f.NumberAllergens)
                    .Value(query)))
          .From((page - 1) * pageSize)
          .Size(pageSize));

            if (!response.IsValid)
            {
                return new Recipe[] { };
            }
            return response.Documents;
        }

        public async Task<IReadOnlyCollection<Recipe>> TitleFindAsync(string query)
        {
            var response = await _elasticClient.SearchAsync<Recipe>(s => s.Query(q => q.Match(t => t.Field(f => f.Title)
            .Query(query))));

            return response.Documents;
        }
    }
}
