using repz_core.mysql;

namespace repz_core.services.recipes
{
    public class RecipeService
    {
        private mysql.RecipeStore _recipeStore;

        public RecipeService(RecipeStore recipeStore)
        {
            _recipeStore = recipeStore;
        }

        public List<views.RecipeTitle>? GetAllRecipes() => _recipeStore.GetAllUnapprovedRecipes();
        public views.RecipeProducts? GetRecipeByID(int id) => _recipeStore.GetRecipeByID(id);
        public bool SetRecipeApproved(int id, bool approved) => _recipeStore.SetRecipeApproved(id, approved);
        public bool CreateRecipe(string title, string description, string[] products)
        {

        }

    }
}
