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

        public bool SetRecipeApproved(int id, bool approved)
        {
            string query = @"UPDATE recipes SET approved = @Approved WHERE id = @Id";

            try
            {
                MySqlHelper.ExecuteNonQuery(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("Id", id), new MySqlParameter("Approved", approved) });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public views.RecipeProducts? GetRecipeByID(int id)
        {
            string recipeQuery = @"SELECT id, title, description, approved FROM recipes 
                            WHERE id = @Id";

            string productIdsQuery = @"SELECT group_concat(rp.product_id) FROM recipes r
                                       JOIN recipe_products rp on rp.recipe_id = r.id 
                                       WHERE r.id = @RecipeID
                                       GROUP BY r.id";

            string productsByIDsQuery = @"SELECT id, name FROM products WHERE FIND_IN_SET(id, @IDs)";

            try
            {
                repz.Recipe recipe;
                using (var reader = MySqlHelper.ExecuteReader(this._dbConn, recipeQuery, new MySqlParameter[] { new MySqlParameter("Id", id) }))
                {
                    if (!reader.HasRows)
                        return null;

                    reader.Read();

                    recipe = new repz.Recipe(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                }

                var ids = Convert.ToString(
                    MySqlHelper.ExecuteScalar(this._dbConn, productIdsQuery, new MySqlParameter[] { new MySqlParameter("RecipeID", id) })
                    );

                List<repz.Product> products = new List<repz.Product>();
                using (var reader = MySqlHelper.ExecuteReader(this._dbConn, productsByIDsQuery, new MySqlParameter[] { new MySqlParameter("IDs", ids) }))
                {
                    while (reader.Read())
                    {
                        var productId = reader.GetInt32(0);
                        var productName = reader.GetString(1);
                        products.Add(new repz.Product(productId, productName));
                    }
                }

                views.RecipeProducts recipeProducts = new views.RecipeProducts(recipe, products);

                return recipeProducts;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<views.RecipeTitle>? GetAllRecipes(bool approved)
        {
            string query = "SELECT id, title, description FROM recipes WHERE approved = @Approved";

            try
            {
                List<views.RecipeTitle> recipes = new List<views.RecipeTitle>();
                var reader = MySqlHelper.ExecuteReader(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("Approved", approved) });
                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var title = reader.GetString(1);
                    var description = reader.GetString(2);

                    recipes.Add(new views.RecipeTitle(id, title, description));
                }

                return recipes;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public int SaveRecipe(string title, string description, bool approved)
        {
            var query = @"INSERT INTO recipes (title,description,approved)
                          VALUES (@Title, @Description, @Approved)";
            try
            {
                MySqlHelper.ExecuteNonQuery(this._dbConn, query, new MySqlParameter[] {
                new MySqlParameter("Title",title),
                new MySqlParameter("Description",description),
                new MySqlParameter("Approved",approved)
                });

                return Convert.ToInt32(MySqlHelper.ExecuteScalar(this._dbConn, "SELECT LAST_INSERT_ID() from recipes;"));
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool AssociateProductsWithRecipe(string[] productIDs, string recipeID)
        {
            var query = @"INSERT INTO recipe_products (product_id,recipe_id)
                          VALUES (@ProductID, @RecipeID)";
            try
            {
                foreach (var pID in productIDs)
                {
                    MySqlHelper.ExecuteNonQuery(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("ProductID", pID), new MySqlParameter("RecipeID", recipeID) });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
