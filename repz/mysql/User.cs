using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysql
{
    public class User
    {
        private string _dbConn;

        public User(string dbConn)
        {
            _dbConn = dbConn;
        }

        public string GetUserByEmail(string email)
        {
            var query = @"SELECT u.id, r.name FROM users u
                          JOIN roles r on r.id = u.role_id
                          WHERE users.email = @Email";

            var reader = MySqlHelper.ExecuteReader(this._dbConn, query, new MySqlParameter[] { new MySqlParameter("Email", email) });
            if (!reader.HasRows) return "";

            reader.Read();



        }
    }
}
