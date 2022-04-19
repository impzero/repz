using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using repz_core.services.user;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace repz_web.Pages.auth
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public RegisterCredentials credentials { get; set; }

        private UserService us;

        public SignUpModel(UserService us)
        {
            this.us = us;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid) return Page();
            if (!us.Register(credentials.Name, credentials.Email, credentials.Password, false)) return Page();

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

    public class RegisterCredentials
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
