namespace repz_core.repz
{
    public class User
    {
        private int _id;
        private string _email;
        private string _name;
        private string _password;
        private Role _role;

        public int ID { get => _id; set => _id = value; }
        public string Email { get => _email; set => _email = value; }
        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
        public Role Role { get => _role; set => _role = value; }

        public User(int id, string email, string name, string password, Role role)
        {
            _id = id;
            _email = email;
            _name = name;
            _password = password;
            _role = role;
        }

        public bool ValidatePassword(string hash)
        {
            return  BCrypt.Net.BCrypt.Verify(this._password, hash);
        }
    }
}