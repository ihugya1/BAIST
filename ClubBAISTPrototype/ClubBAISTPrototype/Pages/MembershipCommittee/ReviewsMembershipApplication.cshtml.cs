using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubBAISTPrototype.Pages.MembershipCommittee
{
    public class ReviewsMembershipApplicationModel : PageModel
    {

       
        [BindProperty]
        public int MembershipApplicationID { get; set; }
        [BindProperty]
  
        public string FirstNameField { get; set; }
        [BindProperty]

        public string LastNameField { get; set; }
        [BindProperty]
  
        public string OccupationField { get; set; }
        [BindProperty]
  
        public string CompanyNameField { get; set; }
        [BindProperty]

        public string HomeAddressField { get; set; }
        [BindProperty]

        public string CompanyAddressField { get; set; }
        [BindProperty]
     
        public string HomePostalCodeField { get; set; }
        [BindProperty]

        public string CompanyPostalCodeField { get; set; }
        [BindProperty]

        public string HomePhoneField { get; set; }
        [BindProperty]
 
        public string CompanyPhoneField { get; set; }
        [BindProperty]
       
        public string HomeAlternatePhoneField { get; set; }
        [BindProperty]

        public string EmailField { get; set; }
        [BindProperty]
      
        public DateTime DateOfBirthField { get; set; }
        [BindProperty]
     
        public string ShareHolder1Field { get; set; }
        [BindProperty]
   
        public string ShareHolder2Field { get; set; }

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

        private List<MembershipApplication> _sampleObjectCollection = new List<MembershipApplication>();
        public List<MembershipApplication> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }


        public void OnGet()
        {
           
             CBS systemControl = new CBS();
            _sampleObjectCollection = systemControl.SearchApplicationsByParam("P");
            this.Options = new List<SelectListItem> {
                    new SelectListItem { Text = "Pending", Value = "P" },
                    new SelectListItem { Text = "Approved", Value = "A" },
                    new SelectListItem { Text = "Rejected", Value = "R" },
                    new SelectListItem { Text = "On-Hold", Value = "H" },
                    new SelectListItem { Text = "Wait Listed", Value = "W" },
                };
            selectedFilter = "P";
            
        }
        public void OnPost()
        {
            this.Options = new List<SelectListItem> {
                   new SelectListItem { Text = "Pending", Value = "P" },
                    new SelectListItem { Text = "Approved", Value = "A" },
                    new SelectListItem { Text = "Rejected", Value = "R" },
                    new SelectListItem { Text = "On-Hold", Value = "H" },
                    new SelectListItem { Text = "Wait Listed", Value = "W" },
                };
            bool confirm;
            selectedFilter = selectedFilter;
            string Parameter;
            MembershipApplication membershipApplication;
            CBS systemControl = new CBS();
            Parameter = selectedFilter;
            string[] subs = Submit.Split(' ');
      

            switch (subs[0])
            {

                case "Search":
                    
                    _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Select":

                    membershipApplication = systemControl.GetMembershipApplication(int.Parse(subs[1]));
                    if (membershipApplication != null)
                    {
                        Message = $"{subs[1]} Selected";
                        MembershipApplicationID = membershipApplication.MembershipApplicationID;
                        FirstNameField = membershipApplication.FirstName;
                        LastNameField = membershipApplication.LastName;
                        HomeAddressField = membershipApplication.HomeAddress;
                        CompanyNameField = membershipApplication.CompanyName;
                        CompanyAddressField = membershipApplication.CompanyAddress;
                        HomePostalCodeField = membershipApplication.HomePostalCode;
                        CompanyPostalCodeField = membershipApplication.CompanyPostalCode;
                        HomePhoneField = membershipApplication.HomePhone;
                        CompanyPhoneField = membershipApplication.CompanyPhone;
                        HomeAlternatePhoneField = membershipApplication.HomeAlternatePhone;
                        EmailField = membershipApplication.Email;
                        DateOfBirthField = membershipApplication.DateOfBirth;
                        ShareHolder1Field = membershipApplication.ShareholderName1;
                        ShareHolder2Field = membershipApplication.ShareholderName2;
                        _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                case "Reject":
                    
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
                    break;
                case "Approve":

                    confirm = systemControl.ApproveMembershipApplication(int.Parse(subs[1]));
                    if (confirm)
                    {
                        Message = $"{subs[1]} Approved";
                        _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                case "Waitlist":

                    confirm = systemControl.WaitListApplication(int.Parse(subs[1]));
                    if (confirm)
                    {
                        Message = $"{subs[1]} put on wait list";
                        _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                case "Hold":

                    confirm = systemControl.HoldApplication(int.Parse(subs[1]));
                    if (confirm)
                    {
                        Message = $"{subs[1]} put on hold";
                        _sampleObjectCollection = systemControl.SearchApplicationsByParam(Parameter);
                    }
                    else
                    {
                        Message = "Error";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
