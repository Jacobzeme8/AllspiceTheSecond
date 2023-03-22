namespace AllspiceTheSecond.Controllers
{
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

    }
}