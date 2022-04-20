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
    }
}
