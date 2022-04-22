using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using repz_core.services.recipes;

namespace repz_web.Pages
{
    public class RecipeModel : PageModel
    {
        public repz_core.views.RecipeProducts recipe { get; set; }
        [BindProperty(SupportsGet = true)]
        public int recipeID { get; set; }
        private readonly RecipeService _rService;

        public RecipeModel(RecipeService rService)
        {
            _rService = rService;
        }

        public IActionResult OnGet()
        {
            this.recipe = _rService.GetRecipeByID(recipeID);
            if (recipe is null) return RedirectToPage("/");

            this.recipe = recipe;
            return Page();
        }
    }
}
