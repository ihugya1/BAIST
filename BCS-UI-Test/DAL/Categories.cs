using BAIS3150_OOPAssignment01_IanHugya_OA02.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.Technical_Services
{
    class Categories
    {
        string connectionString = "Your Connection string here";
        // Manager ADO.NET - Parameters returned
        public List<Product> GetProductsByCategories(int CategoryID)
        {
            List<Product> productList;
            string user = "ihugya1";
            string password = "test";
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database=Northwind;User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = $"{user}.GetProductsByCategory"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@CategoryID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CategoryID
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            productList = new List<Product>();
            if (ASampleDataReader.HasRows)
            {
                Console.WriteLine("\nColumns:");
                Console.WriteLine("--------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    Console.Write(ASampleDataReader.GetName(index)+ " ,");
                }
                Console.WriteLine("Values:");
                Console.WriteLine("-------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                    {
                        string placeHolder="";
                        Product product = new Product();

                        placeHolder = ASampleDataReader.GetValue("ProductID").ToString();
                        product.ProductID = int.Parse(placeHolder);

                        product.ProductName = ASampleDataReader.GetValue("ProductName").ToString();


                        product.QuantityPerUnit = ASampleDataReader.GetValue("QuantityPerUnit").ToString();

                        placeHolder = ASampleDataReader.GetValue("UnitPrice").ToString();
                        product.UnitPrice = double.Parse(placeHolder);


                        placeHolder = ASampleDataReader.GetValue("UnitsInStock").ToString();
                        product.UnitsInStock = int.Parse(placeHolder);

                        placeHolder = ASampleDataReader.GetValue("UnitsOnOrder").ToString();
                        product.UnitsOnOrder = int.Parse(placeHolder);

                        placeHolder = ASampleDataReader.GetValue("ReorderLevel").ToString();
                        product.ReorderLevel = int.Parse(placeHolder);

                        placeHolder = ASampleDataReader.GetValue("Discontinued").ToString();
                        product.Discontinued = bool.Parse(placeHolder);
                        productList.Add(product);
                      
                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return productList;
        }
    }
}
