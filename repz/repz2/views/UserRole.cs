using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repz.views
{
   public class UserRole
    {
        public int UserID { get; set; }
        public string Role { get; set; }

        public UserRole(int userID, string role)
        {
            UserID = userID;
            Role = role;
        }
    }
}
