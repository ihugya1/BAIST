using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using ABC_Hardware.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class SAleTestModel : PageModel
    {
        public int? quantityonhand { get; set; }

        public string itemcode { get; set; }

        public Item item { get; set; }

        public List<Item> items { get; set; }
        public void OnGet()
        {
            quantityonhand = HttpContext.Session.GetInt32("quantityonhand");
            itemcode = HttpContext.Session.GetString("itemcode");

        }
    }
    
}
