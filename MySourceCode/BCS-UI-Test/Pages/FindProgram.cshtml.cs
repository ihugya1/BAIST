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
        public string ProgramCode1 { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public ProgramName program { get; set; }
        public string Message { get; set; }
        public List<Student> EnrolledStudents { get; set; }


        public void OnGet()
        {
            program = new ProgramName();
            Message = $"On Get";
        }
        public void OnPost(string id)
        {
            BCS RequestDirector = new BCS();
            program = RequestDirector.FindProgram(id);
            ProgramCode1 = program.ProgramCode;
            Description = program.Description;
            EnrolledStudents = program.EnrolledStudents;
           
            Message = $"Viewing {program.ProgramCode}";
        }

    }
}
