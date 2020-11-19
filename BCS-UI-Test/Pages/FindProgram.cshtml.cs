using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS_UI_Test.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages
{
    public class FindProgramModel : PageModel
    {
        [BindProperty]
        public string ProgramCode { get; set; }
        [BindProperty]
        public ProgramName program { get; set; } = new ProgramName();
        public string Message { get; set; }



        public void OnGet()
        {
           

        }
        public void OnPost()
        {
            BCS RequestDirector = new BCS();
            program = RequestDirector.FindProgram(ProgramCode);
           
            Message = $"Viewing {program.ProgramCode}";
        }

    }
}
