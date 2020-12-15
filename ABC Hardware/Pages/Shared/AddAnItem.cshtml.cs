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
    public class AddAnItemModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required]
        public string ItemCodeField { get; set; }
        [BindProperty]
        [Required]
        public string ItemDescriptionField { get; set; }
        [BindProperty]
        [Required]
        public decimal UnitPriceField { get; set; }
        [BindProperty]
        [Required]
        public int QuantityOnHandField { get; set; }
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
                Item newItem = new Item
                {
                    ItemCode = ItemCodeField,
                    ItemDescription = ItemDescriptionField,
                    UnitPrice = UnitPriceField,
                    QuantityOnHand = QuantityOnHandField
                };
                ABCCS RequestDirector = new ABCCS();
             
                Confirmation = RequestDirector.AddAnItem(newItem);


                Message = $"{newItem.ItemCode} was added :{Confirmation}";
            }
            else
            {
                Message = $"Not Valid";
            }
        }
    }
}
