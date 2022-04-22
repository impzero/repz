using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using repz_core.services.product;
using repz_core.services.recipes;
using System.ComponentModel.DataAnnotations;

namespace repz_web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CreateRecipeDTO createRecipeDTO { get; set; }

        public List<repz_core.views.Product> products { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private RecipeService _recipeService;

        public IndexModel(ILogger<IndexModel> logger, RecipeService recipeService, ProductService productService)
        {
            _logger = logger;
            _recipeService = recipeService;
            products = productService.GetAllProducts()!;
        }

        public IActionResult OnPost()
        {
            var products = createRecipeDTO.Products.Trim().Split(',');
            _recipeService.CreateRecipe(createRecipeDTO.Title, createRecipeDTO.Description, products);

            return RedirectToPage('/');
        }

        public void OnGet()
        {

        }
    }

    public class CreateRecipeDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Products { get; set; }
    }
}