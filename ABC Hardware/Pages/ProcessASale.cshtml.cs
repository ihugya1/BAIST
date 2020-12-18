using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using ABC_Hardware.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class ProcessASaleModel : PageModel
    {

        public Item item { get; set; }

        public List<Item> items { get; set; }

        [BindProperty]
        public decimal Total { get; set; }
        public string Message { get; set; }
   
        [BindProperty]
        [Required]
        public int SalePersonIDField { get; set; }
        [BindProperty]
        [Required]
        public int CustomerIDField { get; set; }
        public List<SaleItem> saleitems = new List<SaleItem>();

        public void OnGet() {
            items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "saleitems");
            if (items != null)
            {

          
            foreach (var i in items)
            {
                SaleItem saleItem = new SaleItem
                {
                    ItemCode = i.ItemCode,
                    
                };
                saleitems.Add(saleItem);
            }
            }
        }
        
        public void OnPost()
        {
            int saleNum = 0;
            ABCPOS abcpos = new ABCPOS();
            Sale sale = new Sale()
            {
                SalesDate = DateTime.Now,
                CustomerID = 123,
                SalesPersonID = SalePersonIDField,
                SalesItems = saleitems

            };
            try
            {
                saleNum = abcpos.ProcessSale(sale);
            }
            catch (Exception e )
            {

                Message = $"Error : {e}";
            }
          
         
        }
    }

}
