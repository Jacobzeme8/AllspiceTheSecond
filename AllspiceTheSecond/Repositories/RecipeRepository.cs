namespace AllspiceTheSecond.Repositories
{
  public class RecipeRepository
    {
        private readonly IDbConnection _db;

    public RecipeRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe createRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipe
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);
        SELECT LAST_INSERT_ID();
        ;";

        int id = _db.ExecuteScalar<int>(sql, recipeData);
        recipeData.id = id;
        return recipeData;
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

    internal Recipe getRecipeById(int id)
    {
        string sql = @"
        SELECT
        recipe.*,
        accounts.*
        FROM recipe
        JOIN
        accounts ON recipe.creatorId = accounts.id
        WHERE
        recipe.id = @id;
        ";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql,(recipe, account)=>{
            recipe.creator = account;
            return recipe;
        }, new {id} ).FirstOrDefault();
        return recipe;
    }
    }
}