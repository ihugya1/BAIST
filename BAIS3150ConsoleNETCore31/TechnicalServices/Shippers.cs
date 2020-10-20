using BAIS3150ConsoleNETCore31.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BAIS3150ConsoleNETCore31.TechnicalServices
{
    class Shippers
    {
        public bool AddShipper(Shipper newShipper,string user, string password)
        {
            bool Success = true;
            Console.WriteLine("Execute Enroll Student ");
          
            //establish a connection
            //SqlConnection ihugya1 = new SqlConnection();
            SqlConnection BAIS3150;         //declararation
            BAIS3150 = new SqlConnection(); //instantiation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database=Northwind;User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand AddShipperCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            AddShipperCommand.Connection = BAIS3150;
            AddShipperCommand.CommandType = CommandType.StoredProcedure;
            AddShipperCommand.CommandText = "ihugya1.AddShipper";
            SqlParameter AddShipperParameter;
            AddShipperParameter = new SqlParameter //object initialization
            {
                ParameterName = "@ShipperID",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newShipper.ShipperID
            };
            AddShipperCommand.Parameters.Add(AddShipperParameter);
            AddShipperParameter = new SqlParameter
            {
                ParameterName = "@CompanyName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newShipper.CompanyName
            };
            AddShipperCommand.Parameters.Add(AddShipperParameter);
            AddShipperParameter = new SqlParameter
            {
                ParameterName = "@PhoneNumber",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newShipper.Phone
            };
            AddShipperCommand.Parameters.Add(AddShipperParameter);
           
            try
            {
                AddShipperCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Success = false;
                Console.WriteLine(e);
                return Success;
            }
            Console.WriteLine("Success: Added Student");
            Success = true;
            BAIS3150.Close();
            return Success;
        }
    }
}
