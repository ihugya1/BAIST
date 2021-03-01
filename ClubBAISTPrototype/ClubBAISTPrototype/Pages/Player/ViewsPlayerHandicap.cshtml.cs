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
    public class ViewsPlayerHandicapModel : PageModel
    {
        [BindProperty]
        public string selectedFilter { get; set; }
        [BindProperty]
        public string memberName { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public decimal HandicapIndex { get; set; }
        [BindProperty]
        public decimal Best8Total { get; set; }
        [BindProperty]
        public PlayerScore playerScore { get; set; }
        [BindProperty]
        public decimal Last20Average { get; set; }
        [BindProperty]
        public int newMemberNumber { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        private List<int> _sampleObjectCollection = new List<int>();
        public List<int> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }
        private List<int> _top8 = new List<int>();
        public List<int> Top8
        {
            get
            {
                return _top8;
            }
        }



        public void OnGet()
        {
            this.Options = new List<SelectListItem> {
                    new SelectListItem { Text = "1", Value = "1" },
                    new SelectListItem { Text = "2", Value = "2" },
                    new SelectListItem { Text = "3", Value = "3" },
                    new SelectListItem { Text = "4", Value = "4" },
                    new SelectListItem { Text = "5", Value = "5" },
                    new SelectListItem { Text = "6", Value = "6" },
                    new SelectListItem { Text = "7", Value = "7" },
                    new SelectListItem { Text = "8", Value = "8" },
                    new SelectListItem { Text = "9", Value = "9" },
                    new SelectListItem { Text = "10", Value = "10" },
                    new SelectListItem { Text = "11", Value = "11" },
                    new SelectListItem { Text = "12", Value = "12" },
                    new SelectListItem { Text = "13", Value = "13" },
                    new SelectListItem { Text = "14", Value = "14" },
                    new SelectListItem { Text = "15", Value = "15" },
                    new SelectListItem { Text = "16", Value = "16" },
                    new SelectListItem { Text = "17", Value = "17" },
                    new SelectListItem { Text = "18", Value = "18" },
                    new SelectListItem { Text = "19", Value = "19" },
                    new SelectListItem { Text = "20", Value = "20" },
                    new SelectListItem { Text = "21", Value = "21" },
                    new SelectListItem { Text = "22", Value = "22" },
                };

            selectedFilter = "1";

            CBS teetimes = new CBS();


            try
            {

                memberName = teetimes.GetMemberName(int.Parse(selectedFilter));
            }
            catch (Exception e)
            {

                Message = $"Error {e}";

            }
            try
                {
                    HandicapIndex = teetimes.GetHandicapIndex(int.Parse(selectedFilter));
                }
                catch (Exception)
                {

                    Message = "Not enough data for this member";
                }
            try
            {
                _sampleObjectCollection = teetimes.GetLast20Scores(int.Parse(selectedFilter));
            List<int> sortedInt = teetimes.GetLast20Scores(int.Parse(selectedFilter));
                sortedInt.Sort();
                for (int i = 0; i < 7; i++)
                {
                    _top8.Add(sortedInt[i]);
                }

                foreach (var item in _top8)
                {
                    Best8Total += item;
                }
                foreach (var item in _sampleObjectCollection)
                {
                    Last20Average += item;
                }
                Best8Total = Best8Total / 8;
                Last20Average = Last20Average / 20;

            }
            catch (Exception)
            {

                Message = "Not enough data for this member";
            }
           
        }
        public void OnPost()
        {
            this.Options = new List<SelectListItem> {
                    new SelectListItem { Text = "1", Value = "1" },
                    new SelectListItem { Text = "2", Value = "2" },
                    new SelectListItem { Text = "3", Value = "3" },
                    new SelectListItem { Text = "4", Value = "4" },
                    new SelectListItem { Text = "5", Value = "5" },
                    new SelectListItem { Text = "6", Value = "6" },
                    new SelectListItem { Text = "7", Value = "7" },
                    new SelectListItem { Text = "8", Value = "8" },
                    new SelectListItem { Text = "9", Value = "9" },
                    new SelectListItem { Text = "10", Value = "10" },
                    new SelectListItem { Text = "11", Value = "11" },
                    new SelectListItem { Text = "12", Value = "12" },
                    new SelectListItem { Text = "13", Value = "13" },
                    new SelectListItem { Text = "14", Value = "14" },
                    new SelectListItem { Text = "15", Value = "15" },
                    new SelectListItem { Text = "16", Value = "16" },
                    new SelectListItem { Text = "17", Value = "17" },
                    new SelectListItem { Text = "18", Value = "18" },
                    new SelectListItem { Text = "19", Value = "19" },
                    new SelectListItem { Text = "20", Value = "20" },
                    new SelectListItem { Text = "21", Value = "21" },
                    new SelectListItem { Text = "22", Value = "22" },
                };
            selectedFilter = selectedFilter;

            CBS teetimes = new CBS();


            try
            {

                memberName = teetimes.GetMemberName(int.Parse(selectedFilter));
            }
            catch (Exception e)
            {

                Message = $"Error {e}";

            }
            try
            {
                HandicapIndex = teetimes.GetHandicapIndex(int.Parse(selectedFilter));
            }
            catch (Exception)
            {

                Message = "Not enough data for this member";
            }
            try
            {
                _sampleObjectCollection = teetimes.GetLast20Scores(int.Parse(selectedFilter));
                List<int> sortedInt = teetimes.GetLast20Scores(int.Parse(selectedFilter));
                sortedInt.Sort();
                for (int i = 0; i < 7; i++)
                {
                    _top8.Add(sortedInt[i]);
                }

                foreach (var item in _top8)
                {
                    Best8Total += item;
                }
                foreach (var item in _sampleObjectCollection)
                {
                    Last20Average += item;
                }
                Best8Total = Best8Total / 8;
                Last20Average = Last20Average / 20;

            }
            catch (Exception)
            {

                Message = "Not enough data for this member";
            }



        }
    }
}
