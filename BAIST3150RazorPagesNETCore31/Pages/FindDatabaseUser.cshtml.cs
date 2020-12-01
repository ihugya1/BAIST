using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIST3150RazorPagesNETCore31.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150RazorPagesNETCore31.Pages
{
    public class FindDatabaseUserModel : PageModel
    {
        public DatabaseUser CurrentDatabaseUser
        {
            get;set;
        }

        public void OnGet()
        {
            BCS RequestDirector = new BCS();
            CurrentDatabaseUser = RequestDirector.FindDataBaseUser();
        }
    }
}
