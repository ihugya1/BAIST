using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCS_UI_Test.Pages
{
    public class ihugya1CategoriesModel : PageModel
    {
        public List<Category> CategoryCollection { get; set; } = new List<Category>();
        public void OnGet()
        {
            Categories categoryManager = new Categories();
            CategoryCollection = categoryManager.GetNorthwindCategories();
        }
    }
}
