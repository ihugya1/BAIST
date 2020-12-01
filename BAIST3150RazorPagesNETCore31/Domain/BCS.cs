using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIST3150RazorPagesNETCore31.TechnicalServices;
namespace BAIST3150RazorPagesNETCore31.Domain
{
    public class BCS
    {

        public DatabaseUser FindDataBaseUser()
        {
            DatabaseUsers DatabaseUserManager = new DatabaseUsers();

            DatabaseUser CurrentDatabaseUser = DatabaseUserManager.GetDatabaseUser();

            return CurrentDatabaseUser;
        }
    }
}
