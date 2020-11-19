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
    public class EnrollStudentModel : PageModel
    {
        public string Message { get; set; }


        [BindProperty]
        [Required]
        public string ProgramCodeField { get; set; }
        [BindProperty]
        [Required]
        public string FirstNameField { get; set; }
        [BindProperty]
        [Required]
        public string LastNameField { get; set; }
        [BindProperty]
        [Required]
        public string EmailField { get; set; }
        [BindProperty]
        [Required]
        public string StudentIDField { get; set; }


        public void OnGet()
        {
            Message = " on Get ";
        }
        public void OnPost()
        {

            if (ModelState.IsValid)
            {

                bool Confirmation;
                Student AcceptedStudent = new Student
                {
                    StudentID = StudentIDField,
                    FirstName = FirstNameField,
                    LastName = LastNameField,
                    Email = EmailField
                };
                BCS RequestDirector = new BCS();
                Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCodeField);
  
                AcceptedStudent = RequestDirector.FindStudent(AcceptedStudent.StudentID);
              
                Message = $"{AcceptedStudent.FirstName} {AcceptedStudent.LastName} was enrolled :{Confirmation} in the {ProgramCodeField} program";
            }
            else
            {
                Message = $"Not Valid";
            }
        }
    }
}
