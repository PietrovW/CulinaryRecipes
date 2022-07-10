namespace CulinaryRecipes.Aplication.Queries
{
    public interface IGetRecipeQuery
    {
        public string Query { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
