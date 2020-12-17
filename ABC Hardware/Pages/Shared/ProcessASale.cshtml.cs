using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class ProcessASaleModel : PageModel
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

        private List<Item> _sampleObjectCollection2 = new List<Item>();
        public List<Item> SampleObjectCollection2
        {
            get
            {
                return _sampleObjectCollection2;
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
                case "Add":
                    try
                    {
                        Item item = new Item();
                        item = systemControl.GetAnItem(subs[1]);
                        _sampleObjectCollection2.Add(item);
                        Message = $"{subs[1]} added";
                    }
                    catch (Exception e)
                    {

                        Message = $"Error {e}";
                    }
                   
                    break;
                case "Remove":
                    try
                    {
                        Item item = new Item();
                        item = systemControl.GetAnItem(subs[1]);
                        _sampleObjectCollection2.Remove(item);
                        Message = $"{subs[1]} removed";
                    }
                    catch (Exception e)
                    {

                        Message = $"Error {e}";
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
