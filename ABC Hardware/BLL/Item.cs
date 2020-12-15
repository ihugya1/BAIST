using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.BLL
{
    public class Item
    {
        public string ItemCode { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }// Auto-Implemented Property, no loginc in get/set
        public bool IsDeleted { get; set; }
        public int QuantityOnHand { get; set; }// Auto-Implemented Property, no loginc in get/set
        

    }
}
