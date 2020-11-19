
using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.DAL
{
   public class Categories
    {
       
        public List<Category> GetNorthwindCategories()
        {
            List<Category> CategoriesList;
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database=Northwind;User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = $"{user}.GetNorthwindCategories"
            };
         
         
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            CategoriesList = new List<Category>();
            if (ASampleDataReader.HasRows)
            {
                Console.WriteLine("\nColumns:");
                Console.WriteLine("--------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    Console.Write(ASampleDataReader.GetName(index) + " ,");
                }
                Console.WriteLine("Values:");
                Console.WriteLine("-------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                    {
                    
                        Category category = new Category();

                        category.CategoryName = ASampleDataReader.GetValue("CategoryName").ToString();
                        

                        category.Description = ASampleDataReader.GetValue("Description").ToString();

                        category.Picture = ASampleDataReader.GetValue("Picture").ToString();

                       
                        CategoriesList.Add(category);

                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return CategoriesList;
        }
    }
}
