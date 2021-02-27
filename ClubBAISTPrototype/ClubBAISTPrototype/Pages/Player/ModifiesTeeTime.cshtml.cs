using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTPrototype.Pages.Player
{
    public class ModifiesTeeTimeModel : PageModel
    {
        [BindProperty]
        public TeeTime teeTime { get; set; }
        [BindProperty]
        public TimeSpan ts { get; set; }
        [BindProperty]

        public TimeSpan ts2 { get; set; }
        [BindProperty]
        public DateTime dateVal { get; set; }
        [BindProperty]
        public List<SelectListItem> Options { get; set; }

        public string Message { get; set; }
        [BindProperty]
        public DateTime SearchParameter { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        private List<TeeTime> _sampleObjectCollection = new List<TeeTime>();
        public List<TeeTime> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }


        public void OnGet()
        {
            CBS teetimes = new CBS();
            DateTime dateVal = new DateTime(2021, 02, 15);
            teetimes.CreateTeeSheet(dateVal);
            _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(dateVal);


        }
        public void OnPost()
        {

           
           
            CBS systemControl = new CBS();
            string[] subs = Submit.Split(' ');
            

            switch (subs[0])
            {

                case "Search":

                    _sampleObjectCollection = systemControl.GetDailyTeeTimeSheet(dateVal);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Select":

                    teeTime = systemControl.GetTeeTime(DateTime.Parse(subs[1]),DateTime.Parse(subs[2]));
                    if (teeTime != null)
                    {
                      
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                case "Reject":
                    /*
                    confirm = systemControl.RejectMembershipApplication(int.Parse(subs[1]));
                    if (confirm)
                    {
                        Message = $"{subs[1]} Rejected";
                        _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                          */
                    break;
              
                case "Approve":
                    /*
                   confirm = systemControl.RejectMembershipApplication(int.Parse(subs[1]));
                   if (confirm)
                   {
                       Message = $"{subs[1]} Rejected";
                       _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                   }
                   else
                   {
                       Message = "Error";
                   } */
                    break;
               default: 
                    break;

            }

        }
    }
}