using AllspiceTheSecond.Controllers;

namespace AllspiceTheSecond.Repositories
{
    public class IngredientRepository
    {
        private readonly IDbConnection _db;

    public IngredientRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient createIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredient
        (name, quantity, recipeId)
        VALUES
        (@name, @quantity, @recipeId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, ingredientData);
        ingredientData.id = id;
        return ingredientData;
    }

    internal int deleteIngredient(int id)
    {
        string sql = @"
        DELETE FROM
        ingredient
        WHERE
        id = @id;
        ";

        int rows = _db.Execute(sql, new {id});
        return rows;
    }

    internal Ingredient findOne(int id)
    {
        string sql = @"
        SELECT
        *
        FROM ingredient
        WHERE id = @id;
        ";

        Ingredient ingredient = _db.Query<Ingredient>(sql, new{id}).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> getIngredientsByRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredient
        WHERE
        recipeId = @recipeId;
        ";

        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
        return ingredients;
    }

    internal Ingredient updateIngredient(Ingredient original, int id)
    {
        string sql = @"
        UPDATE ingredient
        SET
        name = @name,
        quantity = @quantity
        WHERE id = @id
        ;
        ";

        int row = _db.Execute(sql, original);
        return original;
    }
    }
}