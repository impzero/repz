using MySql.Data.MySqlClient;

namespace repz_core.mysql
{
    public class RoleStore
    {
        private string _dbConn;

        public RoleStore(string dbConn)
        {
            _dbConn = dbConn;
        }

        public int GetAdminRoleID()
        {
            var query = @"SELECT id FROM roles WHERE name = 'admin'";
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(this._dbConn, query));
        }

        public int GetNormalRoleID()
        {
            var query = @"SELECT id FROM roles WHERE name = 'normal'";
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(this._dbConn, query));
        }
    }
}
