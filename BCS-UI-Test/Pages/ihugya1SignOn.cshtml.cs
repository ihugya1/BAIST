using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages
{
    public class ihugya1SignOnModel : PageModel
    {
        public string Message { get; set; }

      
        [BindProperty]
        [RegularExpression("[a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][0-9][0-9][0-9][0-9]")]
        [Required]
        public string UserIDField { get; set; }
        [BindProperty]
        [Required]
        [MinLength(6)]
        public string PasswordField { get; set; }
        public void OnGet()
        {
            Message = " on Get ";
        }
        public void OnPost()
        {

            if (ModelState.IsValid)
            {
                Message = " On Post is Valid";
            }
            else
            {
                Message = " On Post is NOT Valid";
            }
        }
    }
}
