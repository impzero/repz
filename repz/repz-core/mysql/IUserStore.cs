using repz_core.repz;

namespace repz_core.mysql
{
    public interface IUserStore
    {
        bool CreateUser(string name, string email, string password, int roleID);
        User? GetUserByEmail(string loginEmail);
    }
}