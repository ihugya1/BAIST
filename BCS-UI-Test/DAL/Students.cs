using BCS_UI_Test.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BCS_UI_Test.DAL
{
    public class Students
    {
        public bool AddStudent(Student acceptedStudent, string programCode) //parameters, camel casing
        {
            bool Success = true;
            string user = "ihugya1";
            string password = "SimpCord101";
            //establish a connection
            //SqlConnection ihugya1 = new SqlConnection();
            SqlConnection BAIS3150;         //declararation
            BAIS3150 = new SqlConnection(); //instantiation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand AddStudentCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            AddStudentCommand.Connection = BAIS3150;
            AddStudentCommand.CommandType = CommandType.StoredProcedure;
            AddStudentCommand.CommandText = "AddStudent";
            SqlParameter AddStudentParameter;
            AddStudentParameter = new SqlParameter //object initialization
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.StudentID
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.FirstName
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.LastName
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.Email
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            try
            {
                AddStudentCommand.ExecuteNonQuery();//not getting a result back 
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
        public Student GetStudent(string studentID)
        {
            Student student = new Student();
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = studentID
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
                        Console.WriteLine(ASampleDataReader.GetValue(i));
                        student.FirstName = ASampleDataReader.GetValue("FirstName").ToString();
                        student.LastName = ASampleDataReader.GetValue("LastName").ToString();
                        student.Email = ASampleDataReader.GetValue("Email").ToString();
                        student.StudentID = ASampleDataReader.GetValue("StudentID").ToString();
                    }
                }
                BAIS3150.Close();
            }
            BAIS3150.Close();
            return student;
        }
        public bool UpdateStudent(Student student)
        {
            bool success = true;
            string user = "ihugya1";
            string password = "SimpCord101";
            //establish a connection
            //SqlConnection ihugya1 = new SqlConnection();
            SqlConnection BAIS3150;         //declararation
            BAIS3150 = new SqlConnection(); //instantiation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand UpdateStudentCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            UpdateStudentCommand.Connection = BAIS3150;
            UpdateStudentCommand.CommandType = CommandType.StoredProcedure;
            UpdateStudentCommand.CommandText = "UpdateStudent";
            SqlParameter UpdateStudentParameter;
            UpdateStudentParameter = new SqlParameter //object initialization
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = student.StudentID
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = student.FirstName
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = student.LastName
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = student.Email
            };
           
   
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            try
            {
                UpdateStudentCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
                return success;
                throw;
            }
            Console.WriteLine("Success: Updated Student");
            BAIS3150.Close();
            return success;
        }
        public bool DeleteStudent(string studentID)
        {
            bool success = true;
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150;         //declararation
            BAIS3150 = new SqlConnection(); //instantiation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand DeleteStudentCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            DeleteStudentCommand.Connection = BAIS3150;
            DeleteStudentCommand.CommandType = CommandType.StoredProcedure;
            DeleteStudentCommand.CommandText = "StudentDelete";
            SqlParameter DeleteStudentParameter;
            DeleteStudentParameter = new SqlParameter //object initialization
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = studentID
            };
            DeleteStudentCommand.Parameters.Add(DeleteStudentParameter);
            try
            {
                DeleteStudentCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
                return success;
                throw;
            }
            Console.WriteLine("Success: Delete Student");
            BAIS3150.Close();
            return success;
        }
        public List<Student> GetStudentByProgramCode(string programCode)
        {
            List<Student> studentList;
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentsByProgram"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            studentList = new List<Student>();
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
                        Student student = new Student();
                        student.StudentID = ASampleDataReader.GetValue("StudentID").ToString();
                        student.FirstName = ASampleDataReader.GetValue("FirstName").ToString();
                        student.LastName = ASampleDataReader.GetValue("LastName").ToString();
                        student.Email = ASampleDataReader.GetValue("Email").ToString();
                        studentList.Add(student);
                        Console.WriteLine($"{student.StudentID} {student.FirstName},{student.LastName},{student.Email}");
                        Console.WriteLine("-");
                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return studentList;
        }
    }
}

