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
        [BindProperty]
        public int StandingTeeTimeID { get; set; }
        [BindProperty]
        public DateTime DateStart { get; set; }
        [BindProperty]
        public DateTime DateEnd { get; set; }
        [BindProperty]
        public DateTime TeeTimeTime { get; set; }
        [BindProperty]
        public DateTime? ApprovedDate { get; set; }
        [BindProperty]
        public DateTime? ApprovedTeeTime { get; set; }
        [BindProperty]
        public int RequestedDayOfWeek { get; set; }
        [BindProperty]
        public int ShareHolderNumber { get; set; }
        [BindProperty]
        public int MemberNumber2 { get; set; }
        [BindProperty]
        public int MemberNumber3 { get; set; }
        [BindProperty]
        public int MemberNumber4 { get; set; }
        [BindProperty]
        public string ShareHolderName { get; set; }
        [BindProperty]
        public string Member2Name { get; set; }
        [BindProperty]
        public string Member3Name { get; set; }
        [BindProperty]
        public string Member4Name { get; set; }
        [BindProperty]
        public int? NumCarts { get; set; }
        [BindProperty]
        public int? PriorityNumber { get; set; }
        [BindProperty]
        public string EmployeeName { get; set; }
        [BindProperty]
        public int? EmployeeNumber { get; set; }
        [BindProperty]
        public bool IsApproved { get; set; }
        [BindProperty]
        public bool IsCancelled { get; set; }

        [BindProperty]
        public string selectedFilter { get; set; }

        public List<SelectListItem> Options { get; set; }

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
