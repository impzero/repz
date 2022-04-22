using MySql.Data.MySqlClient;

namespace repz_core.mysql
{
    public class ProductStore
    {

        private string _dbConn;

        public ProductStore(string dbConn)
        {
            _dbConn = dbConn;
        }

        public int SaveProduct(string productName)
        {
            var query = @"INSERT INTO products (name) VALUES (@Name)";
            try
            {
                MySqlHelper.ExecuteScalar(this._dbConn, query, new MySqlParameter[] {
                new MySqlParameter("Name", productName),
                });


                return (int)MySqlHelper.ExecuteScalar(this._dbConn, "SELECT LAST_INSERT_ID() from products;");
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<views.Product>? GetAllProducts()
        {
            string query = "SELECT id, name FROM products";

            try
            {
                List<views.Product> products = new List<views.Product>();
                var reader = MySqlHelper.ExecuteReader(this._dbConn, query);
                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);

                    products.Add(new views.Product(id, name));
                }

                return products;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
