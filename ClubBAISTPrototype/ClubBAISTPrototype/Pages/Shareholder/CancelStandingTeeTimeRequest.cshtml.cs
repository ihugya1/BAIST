using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTPrototype.Pages.Shareholder
{
    public class CancelStandingTeeTimeRequestModel : PageModel
    {
       

        public string Message { get; set; }
        [BindProperty]
        public string SearchParameter { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }

        private List<StandingTeeTime> _sampleObjectCollection = new List<StandingTeeTime>();
        public List<StandingTeeTime> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }


        public void OnGet()
        {

            CBS systemControl = new CBS();
            _sampleObjectCollection = systemControl.GetStandingTeeTimeList();
          

        }
        public void OnPost()
        {
            bool confirm = false ;
            CBS systemControl = new CBS();
            string[] subs = Submit.Split(' ');


            switch (subs[0])
            {
                case "Cancel":
                    StandingTeeTime teeTime = new StandingTeeTime();
                    teeTime.StandingTeeTimeID = int.Parse(subs[1]);
                    teeTime.IsCancelled = true;
                    confirm = systemControl.ModifyStandingTeeTime(teeTime);
                    break;
            }
            _sampleObjectCollection = systemControl.GetStandingTeeTimeList();
                   
              


          
        }
    }
}
