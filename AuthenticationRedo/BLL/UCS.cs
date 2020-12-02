using AuthenticationRedo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationRedo.BLL
{
    public class UCS
    {

        public UCSUser FindUser(string email)
        {
            UCSUsers userManager = new UCSUsers();
            UCSUser user = userManager.GetStudent(email);
            return user;
        }

    }
}
