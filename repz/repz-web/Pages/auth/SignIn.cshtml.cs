using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using repz_core.services.user;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace repz_web.Pages.auth
{

    public class SignInModel : PageModel
    {
        [BindProperty]
        public Credentials credentials { get; set; }

        public UserService us { get; set; }

        public SignInModel(UserService us)
        {
            this.us = us;
        }

        public IActionResult OnGet()
        {
            if (User.Identity is null) return Page();

            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var user = us.Login(credentials.Email, credentials.Password);
            if (user is null) return Page();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.NameIdentifier, user.ID.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Index");
        }
    }

    public class Credentials
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
