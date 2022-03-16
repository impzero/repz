using repz_core;
namespace repz_core.services.User
{
    public class UserService
    {
        private mysql.UserStore _userStore;

        public UserService(mysql.UserStore userStore)
        {
            _userStore = userStore;
        }

        public repz.User? Login(string email, string password)
        {
            var user = this._userStore.GetUserByEmail(email);

            if (user is null) return null;
            if (!user.ValidatePassword(password)) return null;

            return user;
        }
    }
}
