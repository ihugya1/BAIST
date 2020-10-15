using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BAIS3150ConsoleNETCore31.Domain;
namespace BAIS3150ConsoleNETCore31.TechnicalServices
{
    class Programs
    {
        public bool AddProgram(string programCode, string description)
        {
            Console.WriteLine("Execute Add program");
            string user,
            password;
            Console.Write("Please enter DB Name : ");
            user = Console.ReadLine();
            Console.Write("Please enter DB Password : ");
            password = Console.ReadLine();
            bool success = true;
            //establish a connection
            //SqlConnection ihugya1 = new SqlConnection();
            SqlConnection BAIS3150; //declararation
            BAIS3150 = new SqlConnection(); //instantiation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            ASampleCommand.Connection = BAIS3150;
            ASampleCommand.CommandType = CommandType.StoredProcedure;
            ASampleCommand.CommandText = "AddProgram";
            SqlParameter ASampleCommandParameter;
            ASampleCommandParameter = new SqlParameter //object initialization
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                //this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                //this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = description
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            try
            {
                ASampleCommand.ExecuteNonQuery(); //not getting a result back 
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine($"Failure: {e}");
                return success;
            }
            Console.WriteLine("Success: ExecuteNonQuery");
            BAIS3150.Close();
            return success;
        }
        public ProgramName GetProgram(string programCode)
        {
            ProgramName program = new ProgramName();
            string user,
            password;
            Console.Write("Please enter DB Name : ");
            user = Console.ReadLine();
            Console.Write("Please enter DB Password : ");
            password = Console.ReadLine();
            Console.WriteLine("ExecuteReadExample");
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetPrograms"
            };
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
                while (ASampleDataReader.Read()) // no value no read (returns true until no rows left to return)
                {
                    for (int i = 0; i < ASampleDataReader.FieldCount; i++)
                    {
                        program.ProgramCode = ASampleDataReader.GetValue("ProgramCode").ToString();
                        program.Description = ASampleDataReader.GetValue("Description").ToString();
                    }
                    Console.WriteLine("-");
                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return program;
        }
    }
}