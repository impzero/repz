using MySql.Data.MySqlClient;
using repz.views;

namespace repz.mysql
{
    public class User
    {
        private string _dbConn;

        public User(string dbConn)
        {
            _dbConn = dbConn;
        }

        public UserRole GetUserByEmail(string email)
        {
            var query = @"SELECT u.id, r.name FROM users u
                          JOIN roles r on r.id = u.role_id
                          WHERE users.email = @Email";

            var reader = MySqlHelper.ExecuteReader(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("Email", email) });
            if (!reader.HasRows) return null;

            reader.Read();
            return new UserRole(reader.GetInt32(0), reader.GetString(1));
        }
    }
}
