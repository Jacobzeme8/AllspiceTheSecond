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

    internal string deleteRecipeById(int id, Account userInfo)
    {
        Recipe recipe = this.getRecipeById(id);
        if(recipe.creatorId != userInfo.Id) throw new Exception("not your recipe to delete man");
        int rows = _repo.deleteRecipeById(id);
        if(rows < 1) throw new Exception("something went wrong man");
        if(rows > 1) throw new Exception("something went REALLY wrong man");
        string message = $"Recipe {recipe.title} has been deleted ";
        return message;
    }

    internal Recipe editRecipe(int id, Recipe updata, Account userInfo)
    {
        Recipe oldRecipe = this.getRecipeById(id);
        if(oldRecipe.creatorId != userInfo.Id) throw new Exception("thats not yours to edit man");
        oldRecipe.title = updata.title != null ? updata.title : oldRecipe.title;
        oldRecipe.img = updata.img != null ? updata.img : oldRecipe.img;
        oldRecipe.instructions = updata.instructions != null ? updata.instructions : oldRecipe.instructions;
        oldRecipe.category = updata.category != null ? updata.category : oldRecipe.category;
        Recipe newRecipe = _repo.editRecipe(oldRecipe);
        return newRecipe;
        
    }

    internal List<Recipe> getAllRecipes()
    {
        List<Recipe> recipes = _repo.getAllRecipes();
        return recipes;
    }

    internal Recipe getRecipeById(int id)
    {
        Recipe recipe = _repo.getRecipeById(id);
        if(recipe == null) throw new Exception("thats an error man id fix that. Your recipe is null");
        return recipe;
    }
}
