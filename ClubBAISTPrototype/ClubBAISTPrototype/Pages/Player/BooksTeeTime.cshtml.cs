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
        public DateTime newTeeTimeTime { get; set; }
        [BindProperty]
        public string memberName { get; set; }
        [BindProperty]
        public int newMemberNumber { get; set; }
        [BindProperty]
        public int newNumOfPlayers { get; set; }
        [BindProperty]
        public int newNumOfCarts { get; set; }

        [BindProperty]
        public TimeSpan ts { get; set; }
        [BindProperty]

        public TimeSpan ts2 { get; set; }
        [BindProperty]
        public DateTime dateVal { get; set; }
        [BindProperty]
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string SelectedFilter { get; set; }
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
           
            DateTime dateVal = new DateTime(2015, 02, 15);

            SearchParameter = DateTime.Now;
            teetimes.CreateTeeSheet(DateTime.Now);
            _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(SearchParameter.Date);


        }
        public void OnPost()
        {
            
            TeeTime newTeeTime = new TeeTime();

            CBS teetimes = new CBS();
            SearchParameter = SearchParameter;
            CBS systemControl = new CBS();

            string[] subs = Submit.Split(' ');


            switch (subs[0])
            {

                case "Search":
                    SearchParameter = SearchParameter;
                    teetimes.CreateTeeSheet(SearchParameter);
                    Console.WriteLine(SearchParameter);
                    _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(SearchParameter.Date);

                    break;
                case "Select":
                    SearchParameter = SearchParameter;
                    newTeeTimeTime = (DateTime.Parse(subs[1]).Add(DateTime.Parse(subs[2]).TimeOfDay));
                    _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(SearchParameter.Date);
                    break;
                case "Submit":
                    _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(SearchParameter.Date);
                    SearchParameter = SearchParameter;
                    newTeeTime = systemControl.GetTeeTime(DateTime.Parse(subs[1]), DateTime.Parse(subs[2]));
                    if (newTeeTime != null)
                    {
                        bool success = false;
                        Message = $"{subs[1]} Selected";
                        newTeeTime.NumCarts = newNumOfCarts;
                        newTeeTime.NumPlayers = newNumOfPlayers;
                        newTeeTime.TeeTimeDate = DateTime.Parse(subs[2]);
                        newTeeTime.MemberNumber = newMemberNumber;
                        newTeeTime.EmployeeName = "";
                        success= systemControl.BookNewTeeTime(newTeeTime);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;


                  

            }
        }


    }
     
}

