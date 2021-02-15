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
        public bool DeleteCustomer(string customerID)
        {
            bool success = true;

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand DeletecustomerCommand = new SqlCommand(); 
            DeletecustomerCommand.Connection = BAIS3150;
            DeletecustomerCommand.CommandType = CommandType.StoredProcedure;
            DeletecustomerCommand.CommandText = "DeleteCustomer";
            SqlParameter DeletecustomerParameter;
            DeletecustomerParameter = new SqlParameter //object initialization
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = customerID
            };
            DeletecustomerCommand.Parameters.Add(DeletecustomerParameter);
            try
            {
                DeletecustomerCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
                return success;
                throw;
            }
            Console.WriteLine("Success: Delete Customer");
            BAIS3150.Close();
            return success;
        }
        public List<Customer> GetCustomerByParam(string searchParam)
        {
            List<Customer> customerList;

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "SearchCustomers"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@SearchParam",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            customerList = new List<Customer>();
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
                        Customer customer = new Customer();
                        customer.CustomerID = int.Parse(ASampleDataReader.GetValue("CustomerID").ToString());
                        customer.CustomerName = ASampleDataReader.GetValue("CustomerName").ToString();
                        customer.Address = (ASampleDataReader.GetValue("Address").ToString());
                        customer.City = (ASampleDataReader.GetValue("City").ToString());
                        customer.Province = (ASampleDataReader.GetValue("Province").ToString());
                        customer.PostalCode = (ASampleDataReader.GetValue("PostalCode").ToString());
                      
                        customerList.Add(customer);

                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return customerList;
        }
        public Customer GetCustomer(string customerCode)
        {
            Customer customer = new Customer();

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetCustomer",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerCode
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
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
                while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                {
                    for (int i = 0; i < ASampleDataReader.FieldCount; i++)
                    {

                        customer.CustomerID = int.Parse(ASampleDataReader.GetValue("CustomerID").ToString());
                        customer.CustomerName = ASampleDataReader.GetValue("CustomerName").ToString();
                        customer.Address = (ASampleDataReader.GetValue("Address").ToString());
                        customer.City = (ASampleDataReader.GetValue("City").ToString());
                        customer.Province = (ASampleDataReader.GetValue("Province").ToString());
                        customer.PostalCode = (ASampleDataReader.GetValue("PostalCode").ToString());
                       

                    }
                }
                BAIS3150.Close();
            }
            BAIS3150.Close();
            return customer;
        }
        public bool UpdateCustomer(Customer newCustomer) //parameters, camel casing
        {
            bool Success = true;
          
            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand AddCustomerCommand = new SqlCommand(); 
            AddCustomerCommand.Connection = BAIS3150;
            AddCustomerCommand.CommandType = CommandType.StoredProcedure;
            AddCustomerCommand.CommandText = "UpdateCustomer";
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
                SqlValue = newCustomer.Address

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
            Console.WriteLine("Success: Updated Customer");
            Success = true;
            BAIS3150.Close();
            return Success;
        }
    }
}
