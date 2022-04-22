using repz_core.repz;

namespace repz_core.views
{
    public class RecipeProducts
    {
        public repz.Recipe Recipe { get; set; }
        public List<repz.Product> Products { get; set; }

        public RecipeProducts(Recipe recipe, List<repz.Product> products)
        {
            Recipe = recipe;
            Products = products;
        }
    }
}
