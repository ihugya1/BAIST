using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages
{
    public class AddCoursePageModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string CourseIDField { get; set; }
        [BindProperty]
        [Required]
        public string OfferingField { get; set; }
        [BindProperty]
        [Required]
        public string HoursField { get; set; }
        public void OnGet()
        {
            Message = " on Get ";
        }
        public void OnPost()
        { 
            if (ModelState.IsValid)
            {
                bool Success;
                Course NewCourse = new Course
                {
                    CourseID = CourseIDField,
                    Hours = int.Parse(HoursField),
                    Offering = OfferingField
                };
                CodeHandler programManager = new CodeHandler();
                Success = programManager.AddCourse(NewCourse);
                Message = $"{Success}";
            }
            else
            {
                Message = " On Post is NOT Valid";
            }
        }
    }
}
