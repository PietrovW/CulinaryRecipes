using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Aplication.Queries;
using CulinaryRecipes.Shared.Domen;
using MassTransit;

namespace CulinaryRecipes.Aplication.QuerieHandler
{
    internal class GetByTitleRecipeQueryHandler : IConsumer<IGetByTitleRecipeQuery>
    {
        private readonly ISearchService _searchService;
        public GetByTitleRecipeQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public  async Task Consume(ConsumeContext<IGetByTitleRecipeQuery> context)
        {
            IReadOnlyCollection<Recipe> report =  await _searchService.FindAsync(query: context.Message.Query, page: context.Message.Page, pageSize: context.Message.PageSize);
            await context.RespondAsync<IReadOnlyCollection<Recipe>>(report);
        }
    }
}
