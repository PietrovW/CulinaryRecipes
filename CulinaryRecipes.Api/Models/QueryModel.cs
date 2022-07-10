namespace CulinaryRecipes.Api.Models
{
    public record QueryModel
    {
        public string Query { get; init; }
        public int Page { get; init; }
        public int PageSize { get; init; }
    }
}
