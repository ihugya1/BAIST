using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class DeleteACustomerModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string SearchParameter { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }

        private List<Customer> _sampleObjectCollection = new List<Customer>();
        public List<Customer> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }


        public void OnGet()
        {
            Message = "*** On Get ***";
        }
        public void OnPost()
        {
            string Parameter;
            bool confirm;
            ABCCS systemControl = new ABCCS();
            Parameter = SearchParameter;
            string[] subs = Submit.Split(' ');

            switch (subs[0])
            {

                case "Search":
                    _sampleObjectCollection = systemControl.SearchCustomersByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Delete":
                    confirm = systemControl.DeleteCustomer(subs[1]);
                    if (confirm)
                    {
                        Message = $"{subs[1]} deleted";
                        _sampleObjectCollection = systemControl.SearchCustomersByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

