using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIST3150RazorPagesNETCore31.Domain;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
 

    public class DynamicDisplaySampleModel : PageModel
    {
        private List<SampleClass> _sampleObjectCollection = new List<SampleClass>();
        public List<SampleClass> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }
        public void OnGet()
        {
            SampleClass SampleObject;
            SampleObject = new SampleClass();
            SampleObject.FirstProperty = "1";
            SampleObject.SecondProperty = "One";
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
    }
}
