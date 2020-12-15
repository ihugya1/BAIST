using ABC_Hardware.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.DAL
{
    public class Customers
    {
        public bool AddCustomer(Customer newCustomer) //parameters, camel casing
        {
            bool Success = true;
            bool isDeleted = false;
            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand AddCustomerCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            AddCustomerCommand.Connection = BAIS3150;
            AddCustomerCommand.CommandType = CommandType.StoredProcedure;
            AddCustomerCommand.CommandText = "AddCustomer";
            SqlParameter AddCustomerParameter;
            AddCustomerParameter = new SqlParameter //object initialization
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.Int,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newCustomer.CustomerID
            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
            AddCustomerParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newCustomer.CustomerName
            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
            AddCustomerParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue =  newCustomer.Address

            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
            AddCustomerParameter = new SqlParameter
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newCustomer.Province
            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
            AddCustomerParameter = new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newCustomer.City
            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
            AddCustomerParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newCustomer.PostalCode
            };
            AddCustomerCommand.Parameters.Add(AddCustomerParameter);
      
           

            try
            {
                AddCustomerCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Success = false;
                Console.WriteLine(e);
                return Success;
            }
            Console.WriteLine("Success: Added Customer");
            Success = true;
            BAIS3150.Close();
            return Success;
        }
    }
}
