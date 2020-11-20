using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BCS_UI_Test.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages
{
    public class CreateProgramModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public ProgramName programName { get; set; }
        [BindProperty]
        [Required]
        public string ProgramCodeField { get; set; }
        [BindProperty]
        [Required]
        public string DescriptionField { get; set; }
        public void OnGet()
        {
            Message = " on Get ";
        }
        public void OnPost()
        {

            if (ModelState.IsValid)
            {
                Message = "Hit";
                bool Confirm;
                ProgramName newProgram = new ProgramName
                {
                     ProgramCode= ProgramCodeField,
                     Description = DescriptionField
                 

                };
                BCS requesterDirectorUI = new BCS();
                Confirm = requesterDirectorUI.CreateProgram(newProgram.ProgramCode, newProgram.Description);
                Message = $"Create program success:{Confirm}";
            }
            else
            {
                Message = $"Not Valid";
            }
        }
        public void OnPostEdit(string id)
        {
            if (ModelState.IsValid)
            {
                bool confirm = false;
                BCS RequestDirector = new BCS();
                programName = RequestDirector.FindProgram(id);
                Message = $"Edit : {confirm}";
            }
        }

    }
}
