using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; //for session GetInt32, SetInt32 , GetString, SetString methods

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class SessionSampleModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            // set initial value
            HttpContext.Session.SetInt32("ValueKey", 0); //references sessions and puts the integer value of 0 with the Key "ValueKey"

            // get intial value
            int Value = (int)HttpContext.Session.GetInt32("ValueKey");

            Message = Value.ToString();


        }
        public void OnPost()
        {
            //get value
            int Value = (int)HttpContext.Session.GetInt32("ValueKey");

            // update
            Value++;

            //set new value
            HttpContext.Session.SetInt32("ValueKey", Value);
            Message = Value.ToString();
        }
    }
}
