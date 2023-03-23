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

    internal int deleteRecipeById(int id)
    {
        string sql = @"
        DELETE
        FROM
        recipe
        WHERE
        recipe.id = @id;
        ";
        int rows = _db.Execute(sql, new {id});
        return rows;
    }

    internal Recipe editRecipe(Recipe oldRecipe)
    {
        string sql = @"
        UPDATE recipe
        SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE
        recipe.id = @id
        ;";
        int rows = _db.ExecuteScalar<int>(sql, oldRecipe);
        return oldRecipe;
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