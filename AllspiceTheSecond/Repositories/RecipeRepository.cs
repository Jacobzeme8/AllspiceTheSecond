namespace AllspiceTheSecond.Repositories
{
  public class RecipeRepository
    {
        private readonly IDbConnection _db;

    public RecipeRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<Recipe> getAllRecipes()
    {
        string sql = @"
        SELECT
        *
        FROM recipe
        JOIN
        accounts ON recipe.creatorId = accounts.id;
        ";

        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => {
            recipe.creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }
    }
}