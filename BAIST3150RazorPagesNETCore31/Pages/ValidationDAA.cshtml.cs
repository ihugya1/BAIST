using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class ValidationDAAModel : PageModel
    {
        
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(5,MinimumLength = 1)]
        public string InputField { get; set; }
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
