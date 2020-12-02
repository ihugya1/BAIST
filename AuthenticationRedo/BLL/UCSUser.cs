using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationRedo.BLL
{
    public class UCSUser
    {
        public string UserID { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashPass { get; set; }
        public string SaltPass { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
    }
}
