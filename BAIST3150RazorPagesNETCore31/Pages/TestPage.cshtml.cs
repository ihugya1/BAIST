using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class TestPageModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]//instead of Request.Form
        public string Field { get; set; }
        public void OnGet()// initial
        {
            Message = "**** OnGet ****";
        }
        public void OnPost() //submit 
        {
            Message = "*** OnPost ***";
           // Field = Request.Form["Field"];

        }
    }
}
