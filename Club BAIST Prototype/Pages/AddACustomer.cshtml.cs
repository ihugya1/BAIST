using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class AddACustomerModel : PageModel
    {
        public string Message { get; set; }


        [BindProperty]
        [Required]
        public int CustomerIDField { get; set; }
        [BindProperty]
        [Required]
        public string CustomerNameField { get; set; }
        [BindProperty]
        [Required]
        public string AddressField { get; set; }
        [BindProperty]
        [Required]
        public string CityField { get; set; }
        [BindProperty]
        [Required]
        public string ProvinceField { get; set; }
        [BindProperty]
        [Required]
        public string PostalCodeField { get; set; }
    

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
                Customer newCustomer = new Customer
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
        }
    }
}
