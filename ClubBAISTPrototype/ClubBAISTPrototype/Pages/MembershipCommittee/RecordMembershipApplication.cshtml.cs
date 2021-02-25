using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTPrototype.Pages.MembershipCommittee
{
    public class RecordMemershipApplicationModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required]
        public string FirstNameField { get; set; }
        [BindProperty]
        [Required]
        public string LastNameField { get; set; }
        [BindProperty]
        [Required]
        public string OccupationField { get; set; }
        [BindProperty]
        [Required]
        public string CompanyNameField { get; set; }
        [BindProperty]
        [Required]
        public string HomeAddressField { get; set; }
        [BindProperty]
        [Required]
        public string CompanyAddressField { get; set; }
        [BindProperty]
        [Required]
        public string HomePostalCodeField { get; set; }
        [BindProperty]
        [Required]
        public string CompanyPostalCodeField { get; set; }
        [BindProperty]
        [Required]
        public string HomePhoneField { get; set; }
        [BindProperty]
        [Required]
        public string CompanyPhoneField { get; set; }
        [BindProperty]
        [Required]
        public string HomeAlternatePhoneField { get; set; }
        [BindProperty]
        [Required]
        public string EmailField { get; set; }
        [BindProperty]
        [Required]
        public DateTime DateOfBirthField { get; set; }
        [BindProperty]
        [Required]
        public string ShareHolder1Field { get; set; }
        [BindProperty]
        [Required]
        public string ShareHolder2Field { get; set; }
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
                MembershipApplication newApplication = new MembershipApplication
                {
                    FirstName = FirstNameField,  
                    LastName = LastNameField,
                    Status = 'P',
                    Occupation = OccupationField,
                    CompanyName = CompanyNameField,
                    HomeAddress = HomeAddressField,
                    CompanyAddress = CompanyAddressField,
                    HomePostalCode = HomePostalCodeField,
                    CompanyPostalCode = CompanyPostalCodeField,
                    HomePhone = HomePhoneField,
                    CompanyPhone = CompanyPhoneField,
                    HomeAlternatePhone = HomeAlternatePhoneField,
                    Email = EmailField,
                    DateOfBirth = DateOfBirthField,
                    DateCompleted = DateTime.Now,
                    ShareholderName1 = ShareHolder1Field,
                    ShareholderName2 = ShareHolder2Field     
                };
                CBS RequestDirector = new CBS();
                Confirmation = RequestDirector.AddMembershipApplication(newApplication);
                Message = $"Error adding {newApplication.FirstName}:{Confirmation}";
            }
            else
            {
                Message = $"Not Valid";
            }
        }
    }
}
