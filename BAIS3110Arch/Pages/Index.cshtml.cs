using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BAIS3110Arch.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string InputTextBox { get; set; }

        public void OnGet()
        {
            Message = "Set in OnGet()";
        }
        public void OnPost()
        {
            Message = DateTime.Now.ToString();
        }
 
    }
}
