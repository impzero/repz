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

        // Marco, Jaap please don't judge me for this part of the code I was rushing a lot of stuff
        // because I did a poor job on my time management 🥺🙏🏼
        public List<views.RecipeTitle>? GetAllFilteredRecipes(string[] filter)
        {
            var recipes = _recipeStore.GetAllRecipes(true);

            List<views.RecipeTitle> repz = new List<views.RecipeTitle>();
            foreach (var product in filter)
            {
                foreach (var recipe in recipes!)
                {
                    if (GetRecipeByID(recipe.ID)!.Products.Select(p => p.Name).Contains(product))
                    {
                        if (!repz.Select(r => r.ID).Contains(recipe.ID))
                        {
                            repz.Add(recipe);
                        }
                    }
                }
            }

            return repz;
        }

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
