using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.BLL
{
    public class Customer
    {
        public int CustomerID { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string CustomerName { get; set; }
        public string Address { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string City { get; set; }
        public string Province { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }// Auto-Implemented Property, no loginc in get/set
    }
}
