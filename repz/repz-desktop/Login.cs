using repz_core.services.User;

namespace repz_desktop
{
    public partial class Login : Form
    {
        private UserService _us;
        public Login(UserService us)
        {
            InitializeComponent();
            this._us = us;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var email = textBox1.Text;
            var password = textBox2.Text;

            var user = this._us.Login(email, password);
            if (user is null)
            {
                MessageBox.Show("Bad credentials");
                return;
            }

            if (user.Role.Name == "admin")
            {
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register form = new Register(_us);
            form.Show();
        }
    }
}