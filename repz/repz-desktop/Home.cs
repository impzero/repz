using repz_core.services.recipes;

namespace repz_desktop
{
    public partial class Home : Form
    {
        private RecipeService _rs;

        public Home(RecipeService rs)
        {
            InitializeComponent();
            this._rs = rs;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            var recipes = _rs.GetAllRecipes();
            if (recipes is null) return;
            listBox1.Items.Clear();
            foreach (var recipe in recipes)
            {
                listBox1.Items.Add($"ID: {recipe.ID}, Title: {recipe.Title}");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = listBox1.SelectedItem.ToString()!.Substring(3, 2);

            var recipe = _rs.GetRecipeByID(Convert.ToInt32(id));

            lblTitle.Text = recipe!.Recipe.Title;
            lblDesc.Text = recipe!.Recipe.Description;
            string productsText = "";

            for (int i = 0; i < recipe!.Products.Count; i++)
            {
                if (i > 0)
                {
                    productsText += ", ";
                }
                productsText += recipe!.Products[i].Name;
            }
            foreach (var p in recipe!.Products)
            {
                productsText += p.Name;
            }

            lblProducts.Text = productsText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = listBox1.SelectedItem.ToString()!.Substring(3, 2);
            if(!_rs.SetRecipeApproved(Convert.ToInt32(id), true))
            {
                MessageBox.Show("Failed to approve recipe");
                return;
            }

            MessageBox.Show("Recipe approved successfuly");
            LoadRecipes();
        }
    }
}
