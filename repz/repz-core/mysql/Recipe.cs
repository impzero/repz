using MySql.Data.MySqlClient;

namespace repz_core.mysql
{
    public class RecipeStore
    {
        private string _dbConn;

        public RecipeStore(string dbConn)
        {
            _dbConn = dbConn;
        }

        public views.RecipeProducts? GetRecipeByID(int id)
        {
            string query = "SELECT p.id, p.name, r.id, r.title, r.description, r.approved FROM recipes r " +
                "JOIN recipe_products rp on rp.recipe_id = r.id " +
                "JOIN products p on p.id = rp.product_id " +
                "WHERE id = @Id";

            try
            {
                views.RecipeProducts? recipe = null;
                var reader = MySqlHelper.ExecuteReader(this._dbConn, query);
                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    var productId = reader.GetInt32(0);
                    var productName = reader.GetString(1);
                    var recipeId = reader.GetInt32(2);
                    var recipeTitle = reader.GetString(3);
                    var recipeDescription = reader.GetString(4);
                    var recipeApproved= reader.GetBoolean(5);

                    recipe = new views.RecipeProducts(new repz.Recipe(recipeId,recipeTitle,recipeDescription,recipeApproved), )

                    var title = reader.GetString(1);

                    recipes.Add(new views.RecipeTitle(id, title));
                }

                return recipes;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<views.RecipeTitle>? GetAllUnapprovedRecipes()
        {
            string query = "SELECT id, title FROM recipes WHERE approved = false";

            try
            {
                List<views.RecipeTitle> recipes = new List<views.RecipeTitle>();
                var reader = MySqlHelper.ExecuteReader(this._dbConn, query);
                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var title = reader.GetString(1);

                    recipes.Add(new views.RecipeTitle(id, title));
                }

                return recipes;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
