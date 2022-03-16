using repz_core.services.user;
using repz_core.services.recipes;

namespace repz_desktop
{
    public partial class Login : Form
    {
        private UserService _us;
        private RecipeService _rs;
        public Login(UserService us, RecipeService rs)
        {
            InitializeComponent();
            this._us = us;
            this._rs = rs;
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
                Home form = new Home(this._rs);
                form.Show();
                this.Hide();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register form = new Register(_us);
            form.Show();
        }
    }
}