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
    }
}
