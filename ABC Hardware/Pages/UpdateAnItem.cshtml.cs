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
    public class UpdateAnItemModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string SearchParameter { get; set; }
       
        [BindProperty]
 
        public string ItemCodeField { get; set; }
        [BindProperty]

        public string ItemDescriptionField { get; set; }
        [BindProperty]
 
        public decimal UnitPriceField { get; set; }
        [BindProperty]
  
        public int QuantityOnHandField { get; set; }
        [BindProperty]
        public string Submit { get; set; }

        private List<Item> _sampleObjectCollection = new List<Item>();
        public List<Item> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }


        public void OnGet()
        {
            Message = "*** On Get ***";
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

                    _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    break;
                case "Select":
                    Item item = new Item();
                    item = systemControl.GetAnItem(subs[1]);
                    ItemCodeField = item.ItemCode;
                    ItemDescriptionField = item.ItemDescription;
                    QuantityOnHandField = item.QuantityOnHand;
                    UnitPriceField = item.UnitPrice;
                    Message = $"{subs[1]} selected";
                     _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                   
                    break;
                case "Update":
                    Item item2 = new Item() { ItemCode = ItemCodeField, ItemDescription = ItemDescriptionField, QuantityOnHand = QuantityOnHandField, UnitPrice = UnitPriceField };
                    try
                    {
                        confirm = systemControl.UpdateAnItem(item2);
                        Message = $"{item2.ItemCode} updated : {confirm}";
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

