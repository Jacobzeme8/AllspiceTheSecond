namespace AllspiceTheSecond.Controllers;

  using Microsoft.AspNetCore.Mvc;

  [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeServices _recipeServices;
        private readonly Auth0Provider _auth;

    public RecipeController(RecipeServices recipeServices, Auth0Provider auth)
    {
        _recipeServices = recipeServices;
        _auth = auth;
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




    }

    
