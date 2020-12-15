using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class DeleteAnItemModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string SearchParameter { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }

        private List<Item> _sampleObjectCollection = new List<Item>();
        public List<Item> SampleObjectCollection
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
                    _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Delete":
                    confirm = systemControl.DeleteAnItem(subs[1]);
                    if (confirm)
                    {
                        Message = $"{subs[1]} deleted";
                        _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
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
