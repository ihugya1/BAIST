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
    public class FindStudentModel : PageModel
    {
        [BindProperty]

        public string FirstNameField { get; set; }
        [BindProperty]

        public string LastNameField { get; set; }
        [BindProperty]

        public string EmailField { get; set; }
        [BindProperty]
        public string StudentIDField { get; set; }

        public string Message { get; set; }

        [BindProperty]
        public Student AcceptedStudent { get; set; }
        public void OnGet()
        {
            AcceptedStudent = new Student();

        }

        public void OnPostView(string id)
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new BCS();
                AcceptedStudent = RequestDirector.FindStudent(id);
                FirstNameField = AcceptedStudent.FirstName;
                LastNameField = AcceptedStudent.LastName;
                EmailField = AcceptedStudent.Email;
                StudentIDField = AcceptedStudent.StudentID;
                Message = $"Viewing {AcceptedStudent.FirstName}";
            }
        }

        public void OnPostDelete(string studentIDField)
        {

            if (ModelState.IsValid)
            {
                bool confirm = false;
                BCS RequestDirector = new BCS();

                confirm = RequestDirector.RemoveStudent(studentIDField);
                Message = $"{confirm}DELETED Student ID {studentIDField}";
            }
        }

        public void OnPostEdit(string studentIDField)
        {
            if (ModelState.IsValid)
            {
                bool confirm = false;

                BCS RequestDirector = new BCS();

                Student modifyStudent = new Student()
                {
                    StudentID = studentIDField,
                    FirstName = FirstNameField,
                    LastName = LastNameField,
                    Email = EmailField
                };


                confirm = RequestDirector.ModifyStudent(modifyStudent);
                Message = $"Edit : {confirm}";
            }
        }


    }
}