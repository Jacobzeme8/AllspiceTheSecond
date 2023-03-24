namespace AllspiceTheSecond.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;
        private readonly Auth0Provider _auth;

    public FavoriteController(Auth0Provider auth, FavoriteService favoriteService)
    {
        _auth = auth;
        _favoriteService = favoriteService;
    }
    

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> createFavorite([FromBody] Favorite favoriteData){
        try 
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.accountId = userInfo.Id;
            Favorite favorite = _favoriteService.createFavorite(favoriteData);
            return favorite;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]


    public ActionResult<String> deleteFavorite(int id){
        string message = _favoriteService.deleteFavorite( id);
        return message;
    }

    }
}