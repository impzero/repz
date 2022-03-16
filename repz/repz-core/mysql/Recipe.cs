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
