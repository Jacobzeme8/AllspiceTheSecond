namespace AllspiceTheSecond.Models
{
  public class Favorite
    {
        public int id { get; set; }
        public string accountId { get; set; }
        public int recipeId { get; set; }
        public Account creator { get; set; }
        public Recipe recipe { get; set; }
    }
}