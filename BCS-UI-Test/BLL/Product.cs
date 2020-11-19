using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.BLL
{
    class Product
    {  //Container class
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit{ get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder{ get; set; }
        public int ReorderLevel{ get; set; }
        public bool Discontinued{ get; set; }
    }
}
