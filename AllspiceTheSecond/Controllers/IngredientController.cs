namespace AllspiceTheSecond.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/ingredients")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;
        private readonly Auth0Provider _auth;

    public IngredientController(IngredientService ingredientService, Auth0Provider auth)
    {
        _ingredientService = ingredientService;
        _auth = auth;
    }

    [HttpPost]
    [Authorize]
    
    public async Task<ActionResult<Ingredient>> createIngredient([FromBody] Ingredient ingredientData){
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Ingredient ingredient = _ingredientService.createIngredient(ingredientData, userInfo);
        return ingredient;
    }

    }
}