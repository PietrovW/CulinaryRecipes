using CulinaryRecipes.Aplication.Common;
using CulinaryRecipes.Aplication.Infrastucture;
using CulinaryRecipes.Shared.Domen;
using MassTransit;

namespace CulinaryRecipes.Aplication.CommandHandler
{
    internal class DeleteRecipeCommonHandler : IConsumer<IDeleteRecipeCommon>
    {
        private readonly ISearchService _searchService;
        public DeleteRecipeCommonHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task Consume(ConsumeContext<IDeleteRecipeCommon> context)
        {
            await _searchService.DeleteAsync(context.Message.Recipe);
        }
    }
}
