using repz_core;
namespace repz_core.services.user
{
    public class UserService
    {
        private mysql.UserStore _userStore;
        private mysql.RoleStore _roleStore;

        public UserService(mysql.UserStore userStore, mysql.RoleStore roleStore)
        {
            _userStore = userStore;
            _roleStore = roleStore;
        }

        public repz.User? Login(string email, string password)
        {
            var user = _userStore.GetUserByEmail(email);

            if (user is null) return null;
            if (!user.ValidatePassword(password)) return null;

            return user;
        }

        public bool Register(string name, string email, string password, bool isAdminRole)
        {
            var bcryptPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));

            if (bcryptPassword is null) return false;

            var roleID = _roleStore.GetNormalRoleID();
            if (isAdminRole)
            {
                roleID = _roleStore.GetAdminRoleID();
            }


            return _userStore.CreateUser(name, email, bcryptPassword, roleID);
        }
    }
}
