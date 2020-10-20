using BAIS3150_OOPAssignment01_IanHugya_OA02.Domain;
using BAIS3150_OOPAssignment01_IanHugya_OA02.Technical_Services;
using System;
using System.Collections.Generic;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category();
            Categories categoryController = new Categories();
            

            category.Products = categoryController.GetProductsByCategories(1);
            foreach (Product prod in category.Products)
            {
                Console.WriteLine($"{ prod.ProductID}, { prod.ProductName},{ prod.QuantityPerUnit}, { prod.UnitPrice}, { prod.UnitsInStock}, { prod.UnitsOnOrder},{prod.ReorderLevel},{prod.Discontinued}");
            }
            Console.ReadLine();
        }
    }
}
