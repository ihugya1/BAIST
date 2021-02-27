using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using ClubBAISTPrototype.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTPrototype.Pages.Player
{
    public class BooksTeeTimeModel : PageModel
    {
        [BindProperty]
        public DateTime newTeeTime { get; set; }
        [BindProperty]
        public int newMemberNumber { get; set; }
        [BindProperty]
        public int numOfPlayers { get; set; }

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
           
            DateTime dateVal = new DateTime(1999, 02, 15);
            newTeeTime = DateTime.Now;
            newMemberNumber = 0;
            numOfPlayers = 0;
          
            if (SearchParameter < dateVal)
            {
                SearchParameter = new DateTime(1999, 02, 15);
            }
            teetimes.CreateTeeSheet(SearchParameter);
            _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(SearchParameter);


        }
        public void OnPost()
        {
            DateTime Parameter;
            TeeTime newTeeTime = new TeeTime();

            CBS teetimes = new CBS();
            Parameter = SearchParameter;
            string[] subs = Submit.Split(' ');

            switch (subs[0])
            {

                case "Search":
                    _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Get":
                    newTeeTime = teetimes.GetTeeTime(DateTime.Parse(subs[1]), DateTime.Parse(subs[2]));
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Modify":
                    newTeeTime = teetimes.GetTeeTime(DateTime.Parse(subs[1]),DateTime.Parse(subs[2]));
                    break;
                default:
                    break;
            }
        }


    }
     
}

