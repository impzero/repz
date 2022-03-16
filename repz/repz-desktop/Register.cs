using repz_core.services.user;

namespace repz_desktop
{
    public partial class Register : Form
    {

        private UserService _us;
        public Register(UserService us)
        {
            InitializeComponent();
            this._us = us;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var email = textBox3.Text;
            var pass = textBox2.Text;

            if (!_us.Register(name, email, pass, true))
            {
                MessageBox.Show("Couldn't create an user");
                return;
            }

            MessageBox.Show("Successfuly created user, now you can login!");
            this.Close();
        }
    }
}
