using MySql.Data.MySqlClient;

namespace repz_core.mysql
{
    public class UserStore
    {
        private string _dbConn;

        public UserStore(string dbConn)
        {
            _dbConn = dbConn;
        }

        public repz.User? GetUserByEmail(string loginEmail)
        {
            var query = @"SELECT u.id, u.email, u.name, u.password, r.id, r.name FROM users u
                          JOIN roles r on r.id = u.role_id
                          WHERE u.email = @Email";

            var reader = MySqlHelper.ExecuteReader(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("Email", loginEmail) });
            if (!reader.HasRows) return null;

            reader.Read();
            var id = reader.GetInt32(0);
            var email = reader.GetString(1);
            var name = reader.GetString(2);
            var password = reader.GetString(3);
            var roleID = reader.GetInt32(4);
            var roleName = reader.GetString(5);

            return new repz.User(id, email, name, password, new repz.Role(roleID, roleName));
        }

        public bool CreateUser(string name, string email, string password, int roleID)
        {
            var query = @"INSERT INTO users (name, email, password, role_id)
                          VALUES (@Name, @Email, @Password, @RoleID)";

            try
            {
                MySqlHelper.ExecuteNonQuery(this._dbConn, query, new MySqlParameter[] {
                new MySqlParameter("Name",name),
                new MySqlParameter("Email",email),
                new MySqlParameter("Password",password),
                new MySqlParameter("RoleID",roleID)});

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}