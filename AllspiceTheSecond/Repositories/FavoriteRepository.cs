namespace AllspiceTheSecond.Repositories;
  public class FavoriteRepository
    {

        private readonly IDbConnection _db;

    public FavoriteRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite createFavorite(Favorite favoriteData)
    {
    string sql = @"
    INSERT INTO
    favorite
    (recipeId, accountId)
    VALUES
    (@recipeId, @accountId);
    SELECT LAST_INSERT_ID();
    ";

    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.id = id;
    return favoriteData;
    }

    internal int deleteFavorite(int id)
    {
        string sql = @"
        DELETE
        FROM
        favorite
        WHERE
        favorite.id = @id;
        ";

        int rows = _db.Execute(sql, new{id});
        return rows;
    }

  internal List<Recipe> GetFavoritesByAccount(string accountId)
    {
    string sql = @"
    SELECT
    recipe.*,
    favorite.*
    FROM
    favorite
    JOIN recipe ON favorite.recipeId = recipe.id
    WHERE
    favorite.accountId = @accountId;
    ";

    List<Recipe> recipes = _db.Query<Recipe, Favorite, Recipe>(sql,(recipe, favorite)=>{
        recipe.favoriteId = favorite.id;
        return recipe;
    } ,new {accountId}).ToList();
    return recipes;
    }
}
