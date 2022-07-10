using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Aplication.Queries;
using CulinaryRecipes.Shared.Domen;
using MassTransit;

namespace CulinaryRecipes.Aplication.QuerieHandler
{
    internal class GetByNumberAllergensQueryHandler : IConsumer<IGetByNumberAllergensRecipeQuery>
    {
        private readonly ISearchService _searchService;
        public GetByNumberAllergensQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public  async Task Consume(ConsumeContext<IGetByNumberAllergensRecipeQuery> context)
        {
            IReadOnlyCollection<Recipe> report =  await _searchService.FindAsync(query: context.Message.Query, page: context.Message.Page, pageSize: context.Message.PageSize);
            await context.RespondAsync<IReadOnlyCollection<Recipe>>(report);
        }
    }
}
