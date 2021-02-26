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
        public string selectedFilter { get; set; }
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
        private List<DateTime> _sampleObjectCollection2 = new List<DateTime>();
        public List<DateTime> SampleObjectCollection2
        {
            get
            {
                return _sampleObjectCollection2;
            }
        }
        private List<DateTime> _sampleObjectCollection3 = new List<DateTime>();
        public List<DateTime> SampleObjectCollection3
        {
            get
            {
                return _sampleObjectCollection3;
            }
        }

        public void OnGet()
        {
            CBS teetimes = new CBS();
            DateTime dateVal = new DateTime(2021, 02, 25);
            _sampleObjectCollection = teetimes.GetDailyTeeTimeSheet(dateVal);


        }
       

    }
     
}

