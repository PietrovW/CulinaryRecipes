using CulinaryRecipes.Shared.Domen;

namespace CulinaryRecipes.Aplication.Infrastucture
{
    public interface ISearchService
    {
        Task<IReadOnlyCollection<Recipe>> FindAsync(string query, int page = 1, int pageSize = 5);
        Task<IReadOnlyCollection<Recipe>> NumberAllergensFindAsync(string query, int page = 1, int pageSize = 5);
        Task<IReadOnlyCollection<Recipe>> TitleFindAsync(string query);
    }
}
