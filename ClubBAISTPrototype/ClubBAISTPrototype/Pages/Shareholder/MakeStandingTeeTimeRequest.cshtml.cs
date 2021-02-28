using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTPrototype.Pages.Shareholder
{
    public class MakeStandingTeeTimeRequestModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required]
        public int Member1NumField { get; set; }
        [BindProperty]
        [Required]
        public int Member2NumField { get; set; }
        [BindProperty]
        [Required]
        public int Member3NumField { get; set; }
        [BindProperty]
        [Required]
        public int Member4NumField { get; set; }
        [Required]
        [BindProperty]
        public string Member1NameField { get; set; }
        [BindProperty]
        [Required]
        public string Member2NameField { get; set; }
        [BindProperty]
        [Required]
        public string Member3NameField { get; set; }
        [BindProperty]
        [Required]
        public string Member4NameField { get; set; }
        [BindProperty]
        [Required]
        public DateTime StartDateField { get; set; }
        [BindProperty]
        [Required]
        public DateTime EndDateField { get; set; }
        [BindProperty]
        [Required]
        public DateTime TeeTimeTimeField { get; set; }
        [BindProperty]
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        public List<SelectListItem> Options { get; set; }

        public void OnGet()
        {
            //  Message = "OnGet";
        }
        public void OnPost()
        {
            // Message = "OnPost";
            if (ModelState.IsValid)
            {
                bool Confirmation;
                StandingTeeTime newStandingTeeTimeRequest = new StandingTeeTime
                {
                    ShareHolderNumber = Member1NumField,
                    MemberNumber2 = Member2NumField,
                    MemberNumber3 = Member3NumField,
                    MemberNumber4 = Member4NumField,
                    ShareHolderName = Member1NameField,
                    Member2Name = Member2NameField,
                    Member3Name = Member3NameField,
                    Member4Name = Member4NameField,
                    DateStart = StartDateField,
                    DateEnd = EndDateField,
                    TeeTimeTime = TeeTimeTimeField,
                    RequestedDayOfWeek = Convert.ToInt32(DayOfWeek) + 1

                };
                CBS RequestDirector = new CBS();
                Confirmation = RequestDirector.InsertStandingTeeTimeRequest(newStandingTeeTimeRequest);
                if (Confirmation==false)
                {
                    Message = $"Successfully added Standing Tee Time Request for {Member1NameField}";
                   
                }
                else
                {
                    Message = $"Error adding Standing Tee Time Request for {Member1NameField}";
                }
               
            }
            else
            {
                Message = $"Not Valid";
            }
        }
    }
}
