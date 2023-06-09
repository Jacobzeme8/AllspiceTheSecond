using AllspiceTheSecond.Controllers;

namespace AllspiceTheSecond.Services
{
  public class IngredientService
    {
        private readonly IngredientRepository _repo;
        private readonly RecipeServices _recipeServices;

    public IngredientService(IngredientRepository repo, RecipeServices recipeServices)
    {
        _repo = repo;
        _recipeServices = recipeServices;
    }

    internal Ingredient createIngredient(Ingredient ingredientData, Account userInfo)
    {
        Recipe recipe = _recipeServices.getRecipeById(ingredientData.recipeId);
        if(recipe.creatorId != userInfo.Id) throw new Exception("Not your recipie to add an ingrident to! nerd!");
        Ingredient ingredient = _repo.createIngredient(ingredientData);
        return ingredient;
    }

    internal string deleteIngredient(int id, Account userInfo)
    {
        int rows = _repo.deleteIngredient(id);
        string message = $"{rows} ingredient has been deleteds";
        return message;
    }

    internal Ingredient editIngredient(Ingredient updata, int id)
    {
        Ingredient original = _repo.findOne(id);
        original.name = updata.name;
        original.quantity = updata.quantity;
        Ingredient ingredient = _repo.updateIngredient(original, id);
        return ingredient;
    }

    internal List<Ingredient> getIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.getIngredientsByRecipe(recipeId);
        return ingredients;
    }
    }
}