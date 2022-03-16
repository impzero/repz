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

        }
    }
}