namespace CulinaryRecipes.Api.Models
{
    public class RecipeModel
    {
        public string Title { get; init; }
        public string Portion { get; init; }

        public float Time { get; init; }
        public string Components { get; init; }

        public string Steps { get; init; }
        public int GlycemicIndex { get; init; }
        public int NumberAllergens { get; init; }

        public int EnergyPerServing { get; init; }

        public string Kitchens { get; init; }
        public string RecipeSuitableFor { get; init; }
        public string Diet { get; init; }
    }
}
