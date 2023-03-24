namespace AllspiceTheSecond.Services
{
  public class FavoriteService
    {
        private readonly FavoriteRepository _repo;

    public FavoriteService(FavoriteRepository repo)
    {
        _repo = repo;
    }

    internal Favorite createFavorite(Favorite favoriteData)
    {
        Favorite favorite = _repo.createFavorite(favoriteData);
        return favorite;
    }

    internal string deleteFavorite(  int id)
    {
        int rows = _repo.deleteFavorite(id);
        string message = $"{rows} favorite was deleted";
        return message;
    }

    internal List<Recipe> GetFavoritesByAccount(Account userInfo)
    {
        List<Recipe> favorites = _repo.GetFavoritesByAccount(userInfo.Id);
        return favorites;
    }
    } 
}