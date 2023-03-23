namespace AllspiceTheSecond.Controllers;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeServices _recipeServices;
        private readonly Auth0Provider _auth;
        private readonly IngredientService _ingredientService;

  public RecipeController(RecipeServices recipeServices, Auth0Provider auth, IngredientService ingredientService)
  {
    _recipeServices = recipeServices;
    _auth = auth;
    _ingredientService = ingredientService;
  }


  [HttpGet]
    [Authorize]
    public ActionResult<List<Recipe>> getAllRecipes(){
        List<Recipe> recipes = _recipeServices.getAllRecipes();
        return recipes;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> createRecipe([FromBody] Recipe recipeData){
        try 
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = _recipeServices.createRecipe(userInfo.Id, recipeData);
            return recipe;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

        [HttpGet("{id}")]
        [Authorize]
        public  ActionResult<Recipe> getRecipeById(int id){
            try 
            {
                Recipe recipe =  _recipeServices.getRecipeById(id);
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipe>> editRecipe(int id, [FromBody] Recipe updata){
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Recipe recipe = _recipeServices.editRecipe(id, updata, userInfo);
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<String>> deleteRecipeById(int id){
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                string message =  _recipeServices.deleteRecipeById(id, userInfo);
                return message;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> getIngredientsByRecipe(int id){
            List<Ingredient> ingredients = _ingredientService.getIngredientsByRecipe(id);
            return ingredients;
        }

    }

    
