using repz_core.mysql;

namespace repz_core.services.recipes
{
    public class RecipeService
    {
        private RecipeStore _recipeStore;
        private ProductStore _productStore;

        public RecipeService(RecipeStore recipeStore, ProductStore productStore)
        {
            _recipeStore = recipeStore;
            _productStore = productStore;
        }

        public List<views.RecipeTitle>? GetAllRecipes(bool approved) => _recipeStore.GetAllRecipes(approved);
        public views.RecipeProducts? GetRecipeByID(int id) => _recipeStore.GetRecipeByID(id);
        public bool SetRecipeApproved(int id, bool approved) => _recipeStore.SetRecipeApproved(id, approved);
        public bool CreateRecipe(string title, string description, string[] products)
        {
            try
            {
                var recipeID = _recipeStore.SaveRecipe(title, description, false);
                List<string> productIds = new List<string>(products.Length);
                foreach (var product in products)
                {
                    productIds.Add(_productStore.SaveProduct(product).ToString());
                }

                if (!_recipeStore.AssociateProductsWithRecipe(productIds.ToArray(), recipeID.ToString()))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
