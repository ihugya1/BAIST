using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAIST.Pages
{
    public class BookTeeTimeModel : PageModel
    {
        public string Message { get; set; }


        [BindProperty]
        [Required]
        public DateTime DateField { get; set; }
        [BindProperty]
        [Required]
        public DateTime TimeField { get; set; }
        [BindProperty]
        [Required]
        public string AddressField { get; set; }
        [BindProperty]
        [Required]
        public string DayOfWeekField { get; set; }
        [BindProperty]
        [Required]
        public string MemberNameField { get; set; }
        [BindProperty]
        [Required]
        public string EmployeeField { get; set; }
        [BindProperty]
        [Required]
        public DateTime DateTimeCreated { get; set; }

        public void OnGet()
        {
            Message = "On Get";
        }
        public void OnPost()
        {
            Message = "OnPost";
            if (ModelState.IsValid)
            {

                bool Confirmation;
                /*   Customer newCustomer = new Customer
                   {
                       CustomerID = CustomerIDField,
                       CustomerName = CustomerNameField,
                       Address = AddressField,
                       City = CityField,
                       Province = ProvinceField,
                       PostalCode = PostalCodeField
                   };
                   ABCCS RequestDirector = new ABCCS();

                   Confirmation = RequestDirector.AddCustomer(newCustomer);


                   Message = $"{newCustomer.CustomerName} was added :{Confirmation}";
               }
               else
               {
                   Message = $"Not Valid";
               }
                */
            }
        }
    }
}
