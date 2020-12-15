using BCS_UI_Test.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BCS_UI_Test.DAL
{
    public class Programs
    {
        public bool AddProgram(string programCode, string description)
        {

           
            bool success = true;

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
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
        public ProgramName GetPrograms()
        {
            ProgramName program = new ProgramName();

            string user = "ihugya1";
            string password = "SimpCord101";
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
        public ProgramName GetProgram(string programCode)
        {
           
            string user = "ihugya1";
            string password = "SimpCord101";
            ProgramName program = new ProgramName();

            SqlConnection BAIS3150 = new SqlConnection();
           
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand GetProgramCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };


            SqlParameter GetProgramParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            GetProgramCommand.Parameters.Add(GetProgramParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = GetProgramCommand.ExecuteReader();
         
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
                        program.ProgramCode = programCode;
                        program.Description = ASampleDataReader.GetValue("Description").ToString();
                        program.EnrolledStudents = GetStudentByProgramCode(programCode);
                    }
                    Console.WriteLine("-");
                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return program;
        }
        public List<Student> GetStudentByProgramCode(string programCode)
        {
            string user = "ihugya1";
            string password = "SimpCord101";
            List<Student> studentList;
            SqlConnection BAIS3150 = new SqlConnection();
          
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
           
         

            SqlCommand GetStudentByCodeCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentsByProgram"
            };


            SqlParameter GetStudentByCodeParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };


            GetStudentByCodeCommand.Parameters.Add(GetStudentByCodeParameter);
            SqlDataReader GetStudentByCodeReader;
            GetStudentByCodeReader = GetStudentByCodeCommand.ExecuteReader();


            studentList = new List<Student>();
            if (GetStudentByCodeReader.HasRows)
            {
                while (GetStudentByCodeReader.Read())// no value no read (returns true until no rows left to return)
                {
                    Student student = new Student();
                    student.StudentID = GetStudentByCodeReader.GetValue("StudentID").ToString();
                    student.FirstName = GetStudentByCodeReader.GetValue("FirstName").ToString();
                    student.LastName = GetStudentByCodeReader.GetValue("LastName").ToString();
                    student.Email = GetStudentByCodeReader.GetValue("Email").ToString();
                    studentList.Add(student);

                }

            }
            GetStudentByCodeReader.Close();
            BAIS3150.Close();
            return studentList;
        }
    }
}
