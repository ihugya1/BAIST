using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.BLL
{
    public class Sale
    {

        public int SaleNumber { get; set; }// Auto-Implemented Property, no loginc in get/set
        public int CustomerID { get; set; }
        public int  SalesPersonID { get; set; }// Auto-Implemented Property, no loginc in get/set
        public DateTime SalesDate { get; set; }
        public List<SaleItem> SalesItems = new List<SaleItem>();
     

    }
}
