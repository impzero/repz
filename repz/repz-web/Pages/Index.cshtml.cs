using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace repz_web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CreateRecipeDTO createRecipeDTO { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {

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