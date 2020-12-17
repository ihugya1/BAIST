using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class UpdateACustomerModel : PageModel
    {
        [BindProperty]
        public string SearchParameter { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public int CustomerIDField { get; set; }
        [BindProperty]

        public string CustomerNameField { get; set; }
        [BindProperty]

        public string AddressField { get; set; }
        [BindProperty]

        public string CityField { get; set; }
        [BindProperty]

        public string ProvinceField { get; set; }
        [BindProperty]

        public string PostalCodeField { get; set; }
        [BindProperty]
        public string Submit { get; set; }

        private List<Customer> _sampleObjectCollection = new List<Customer>();
        public List<Customer> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string Parameter;
            bool confirm;
            ABCCS systemControl = new ABCCS();
            Parameter = SearchParameter;
            string[] subs = Submit.Split(' ');

            switch (subs[0])
            {

                case "Search":

                    _sampleObjectCollection = systemControl.SearchCustomersByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Select":
                    Customer customer = new Customer();
                    customer = systemControl.GetACustomer(subs[1]);
                    CustomerIDField = customer.CustomerID;
                    CustomerNameField = customer.CustomerName;
                    AddressField = customer.Address;
                    CityField = customer.City;
                    ProvinceField = customer.Province;
                    PostalCodeField = customer.PostalCode;
                    Message = $"{subs[1]} selected";
                    _sampleObjectCollection = systemControl.SearchCustomersByParam(Parameter);

                    break;
                case "Update":
                    Customer customer2 = new Customer() { CustomerID = CustomerIDField, CustomerName = CustomerNameField, Address = AddressField, City = CityField, Province = ProvinceField , PostalCode = PostalCodeField };
                    try
                    {
                        confirm = systemControl.UpdateACustomer(customer2);
                        Message = $"{customer2.CustomerID} updated : {confirm}";
                    }
                    catch (Exception e)
                    {
                        Message = $"Error {e}";
                        throw;
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
