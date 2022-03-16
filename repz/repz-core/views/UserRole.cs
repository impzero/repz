using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repz_core.views
{
    public class UserRole
    {
        public repz.User User { get; set; }
        public repz.Role Role { get; set; }

        public UserRole(repz.User u, repz.Role r)
        {
            this.User = u;
            this.Role = r;
        }
    }
}
