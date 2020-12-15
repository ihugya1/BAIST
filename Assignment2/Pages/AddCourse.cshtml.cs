using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2.Pages
{
    public class AddCourseModel : PageModel
    {
        bool success { get; set; }
   
        public string Message { get; set; }
       
        public string courseID { get; set; }
      
        public string hours { get; set; }
       
        public string offering { get; set; }
     
        public void OnGet()
        {
        }
        public void OnPost()
        {
           
            courseID = Request.Form["CourseIDField"];
            hours = Request.Form["HoursField"];
            offering = Request.Form["OfferingField"];

            if (offering == "PT" || offering == "FT")
            {

            
                Course course = new Course
                {
                    CourseID = courseID,
                    Hours = int.Parse(hours),
                    Offering = offering

                };

         //       CodeHandler codeHandler = new CodeHandler();
          //      success = codeHandler.AddCourse(course);

         //       if (success==true)
        //        {
         //           Message = "Course was added successfully";
        //        }
        //        else
        //        {
        //            Message = "Course was not added successfully";
       //         }

            }
            else
            {
                Message = "Offering is not valid";
            }

        }
}
}
