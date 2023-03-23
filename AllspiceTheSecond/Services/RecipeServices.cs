namespace AllspiceTheSecond.Services;

  public class RecipeServices
    {
        private readonly RecipeRepository _repo;

    public RecipeServices(RecipeRepository repo)
    {
        _repo = repo;
    }

    internal Recipe createRecipe(string id, Recipe recipeData)
    {
        recipeData.creatorId = id;
        Recipe recipe = _repo.createRecipe(recipeData);
        return recipe;
    }

    internal List<Recipe> getAllRecipes()
    {
        List<Recipe> recipes = _repo.getAllRecipes();
        return recipes;
    }
    }
