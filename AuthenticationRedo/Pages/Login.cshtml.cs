using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationRedo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set;}
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            string UserEmail = "bob@nait.ca";
            string UserName = "Bob";
            string UserPassword = "123";
            string UserRole = "Admin";
            if (Email==UserEmail)
            {
                if (Password==UserPassword)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserRole));
                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {

                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Admin/Index");
                }
            }
            Message = "Invalid Attempt";
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
