using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class MultiplePostsModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string FirstInputField { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        public void OnGet()
        {
            Message = "*** On Get ***";
        }
        public void OnPost()
        {
            switch (Submit)
            {
                case "First":
                    Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Second":
                    Message = $"On Post - Second - {SecondInputField}";
                    break;
                default:
                    break;
            }  
        }
    }
}
