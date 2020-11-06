using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.DAL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.Technical_Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.Domain
{
    class CodeHandler
    {
        //Conroller = Call the Manager -> Return what was returned
        public bool AddCourse(Course aNewCourse)
        {
            
            bool confirmation;
            Courses courseManager = new Courses();
            confirmation = courseManager.AddCourse(aNewCourse);
            return confirmation;
        }
        public List<Product> GetProductsForCategory(int categoryID)
        {
            List<Product> productList = new List<Product>();
            Categories categoryManager = new Categories();
            productList = categoryManager.GetProductsByCategories(categoryID);
            return productList;

        }
    }
}
