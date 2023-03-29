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

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<String>> deleteIngredient(int id){
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _ingredientService.deleteIngredient(id, userInfo);
        return message;
    }

    [HttpPut]
    [Authorize("{id}")]

    public async Task<ActionResult<Ingredient>> editIngredient([FromBody] Ingredient updata, int id){
        try 
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Ingredient ingredient = _ingredientService.editIngredient(updata, id);
            return ingredient;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    }
}