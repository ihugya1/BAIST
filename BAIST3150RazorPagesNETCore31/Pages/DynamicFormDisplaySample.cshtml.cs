using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIST3150RazorPagesNETCore31.Domain;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class DynamicFormDisplaySampleModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string AField { get; set; }
        [BindProperty]
        public string ACollection { get; set; }
        public List<SampleClass> SampleObjectCollection { get; } = new List<SampleClass>();
        public void OnGet()
        {
            Message = "*** On Get ***";

            SampleClass SampleObject;

            SampleObject = new SampleClass
            {
                FirstProperty = "1",
                SecondProperty = "One"
            };
            SampleObjectCollection.Add(SampleObject);
            SampleObject = new SampleClass
            {
                FirstProperty = "2",
                SecondProperty = "Two"
            };
            SampleObjectCollection.Add(SampleObject);
            SampleObject = new SampleClass
            {
                FirstProperty = "3",
                SecondProperty = "Three"
            };
            SampleObjectCollection.Add(SampleObject);
        }
        public void OnPost()
        {
            Message = " *** ON POST *** " + AField + " - " + ACollection;
        }
    }
}
