using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BCS_UI_Test.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages.Shared
{
    public class RemoveAStudentModel : PageModel
    {
        [BindProperty]
        [Required]
        public string StudentIDField { get; set; }
        [BindProperty]
       
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string StudentID = StudentIDField;
            if (ModelState.IsValid)
            {
                bool confirm = false;
                BCS RequestDirector = new BCS();

                confirm = RequestDirector.RemoveStudent(StudentID);
                Message = $"DELETED Student ID {StudentID} {confirm}";
            }
        }
    }
}
