namespace AllspiceTheSecond.Services
{
  public class RecipeServices
    {
        private readonly RecipeRepository _repo;

    public RecipeServices(RecipeRepository repo)
    {
        _repo = repo;
    }
    }
}