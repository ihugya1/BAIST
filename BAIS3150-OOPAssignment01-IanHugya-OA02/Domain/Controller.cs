using BAIS3150_OOPAssignment01_IanHugya_OA02.Technical_Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.Domain
{
    class Controller
    {
        //Conroller = Call the Manager -> Return what was returned
        public List<Product> FindProductsByCategory(int categoryID)
        {
            Categories categoryManager = new Categories();
            List<Product> productList = new List<Product>();
            productList = categoryManager.GetProductsByCategories(categoryID);
            return productList;
        }
    }
}
