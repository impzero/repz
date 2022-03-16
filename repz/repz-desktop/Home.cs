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
            var recipes = _rs.GetAllRecipes();
            if (recipes is null) return;
            foreach (var recipe in recipes)
            {
                listBox1.Items.Add($"ID: {recipe.ID}, Title: {recipe.Title}");
            }
        }
    }
}
