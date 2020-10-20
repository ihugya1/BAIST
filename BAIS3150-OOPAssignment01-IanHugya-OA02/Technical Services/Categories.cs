using BAIS3150_OOPAssignment01_IanHugya_OA02.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.Technical_Services
{
    class Categories
    {
        public List<Product> GetProductsByCategories(int CategoryID)
        {
            List<Product> productList;
            Console.WriteLine("Execute Get Student By ProgramCode");
            string user, password;
            Console.Write("Please enter DB Name : ");
            user = Console.ReadLine();
            Console.Write("Please enter DB Password : ");
            password = Console.ReadLine();
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database=Northwind;User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ihugya1.GetProductsByCategory"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@CategoryID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = 1
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            productList = new List<Product>();
            if (ASampleDataReader.HasRows)
            {
                Console.WriteLine("Columns:");
                Console.WriteLine("--------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    Console.WriteLine(ASampleDataReader.GetName(index));
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

                       // placeHolder = ASampleDataReader.GetValue("SupplierID").ToString();
                       // product.SupplierID = int.Parse(placeHolder);

                      // placeHolder = ASampleDataReader.GetValue("CategoryID").ToString();
                       // product.CategoryID = int.Parse(placeHolder);

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
                       // Console.WriteLine($"{student.StudentID} {student.FirstName},{student.LastName},{student.Email}");
                       // Console.WriteLine("-");
                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return productList;
        }
    }
}
