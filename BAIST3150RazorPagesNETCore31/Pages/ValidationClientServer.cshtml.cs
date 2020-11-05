using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class ValidationClientServerModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string InputField { get; set; }
        public void OnGet()
        {
            Message = "***OnGet***";
        }
        public void OnPost()
        {

            // validate - Server 
            if (InputField == null||!(InputField.Length > 0 && InputField.Length <= 5))
            {
                ModelState.AddModelError("InputField", "Input field is required and must contain up to 5 characters.");
            }
            if (ModelState.IsValid)//check the model state
            {
                Message = "***OnPost - Valid***";
            }
            else
            {
                Message = "** OnPost *** NOT valid";
            }
        }
    }
}
