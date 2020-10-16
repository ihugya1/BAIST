using Microsoft.SqlServer.Server;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using BAIS3150ConsoleNETCore31.Domain;
using BAIS3150ConsoleNETCore31.TechnicalServices;
using System.Collections.Generic;

namespace BAIS3150ConsoleNETCore31
{
    class Program
    {
        static void ExecuteNonQueryExample(string user,string password) 
        {
            Console.WriteLine("ExecuteNonQueryExample");
            string programName, programCode;
            Console.Write("Please enter Program Name : ");
            programName = Console.ReadLine();
            Console.Write("Please enter student Program Code : ");
            programCode = Console.ReadLine();
            //establish a connection
            //SqlConnection ihugya1 = new SqlConnection();
            SqlConnection BAIS3150;         //declararation
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
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = programName
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            try
            {
                ASampleCommand.ExecuteNonQuery();//not getting a result back 
                Console.WriteLine("Success: ExecuteNonQuery");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failure: {e}");
            }
            BAIS3150.Close();
        }
        static void ExecuteReaderExample(string user, string password)
        {
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
                while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                {
                    for (int i = 0; i < ASampleDataReader.FieldCount; i++)
                    {
                        Console.WriteLine(ASampleDataReader.GetValue(i));
                    }
                    Console.WriteLine("-");
                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
        }
        static void ExecuteScalarExample(string user, string password)
        {
            Console.WriteLine("ExecuteScalarExample");
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "SAMPLE1"
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter); //will receive error message?
            Console.WriteLine(ASampleCommand.ExecuteScalar().ToString());//Execute request and because we know it is one value it will return it
            BAIS3150.Close();
        }
        static void ExecuteGetStudent(string user, string password)
        {
            Console.WriteLine("ExecuteScalarExample");
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
                SqlValue = "123456789"
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter); //will receive error message?
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
                        Console.WriteLine(ASampleDataReader.GetValue("FirstName"));
                    }
                    Console.WriteLine("-");
                }
                BAIS3150.Close();
            }
        }
        static void ExecuteGetProgram(string user, string password)
        {
            Console.WriteLine("ExecuteGetProgram");
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand GetProgramCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };
            SqlParameter GetProgramCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            GetProgramCommand.Parameters.Add(GetProgramCommandParameter);
            Console.WriteLine(GetProgramCommand.ExecuteScalar().ToString());
            BAIS3150.Close();
        }
        static void ExecuteDeleteStudent(string user, string password)
        {
            Console.WriteLine("Execute Delete Student ");
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
                SqlValue = "123456789"
            };
            DeleteStudentCommand.Parameters.Add(DeleteStudentParameter);
            DeleteStudentCommand.ExecuteNonQuery();//not getting a result back 
            Console.WriteLine("Success: Delete Student");
            BAIS3150.Close();
        }//eoExecuteDeleteStudent
        static void ExecuteGetStudentByProgramCode(string user, string password)
        {
            Console.WriteLine("Execute Get Student By ProgramCode");
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
                    }
                    Console.WriteLine("-");
                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
        }
        static void ExecuteAddStudent(string user, string password)
        {
            Console.WriteLine("Execute Add Student ");
            string studentID, firstName, lastName, email, programCode;
            Console.Write("Please enter Student ID : ");
            studentID = Console.ReadLine();
            Console.Write("Please enter student First Name : ");
            firstName = Console.ReadLine();
            Console.Write("Please enter student Last Name : ");
            lastName = Console.ReadLine();
            Console.Write("Please enter student Email : ");
            email = Console.ReadLine();
            Console.Write("Please enter student Program Code : ");
            programCode = Console.ReadLine();
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
                SqlValue = studentID
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = firstName
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = lastName
            };
            AddStudentCommand.Parameters.Add(AddStudentParameter);
            AddStudentParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = email
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
            AddStudentCommand.ExecuteNonQuery();//not getting a result back 
            Console.WriteLine("Success: Added Student");
            BAIS3150.Close();
        }
        static void ExecuteUpdateStudent(string user, string password)
        {
            Console.WriteLine("Execute Add Student ");
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
                SqlValue = "123456788"
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = "Larry"
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = "larLarLar"
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = "larry@larrys.com"
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = "PHOT"
            };
            UpdateStudentCommand.Parameters.Add(UpdateStudentParameter);
            UpdateStudentCommand.ExecuteNonQuery();//not getting a result back 
            Console.WriteLine("Success: Updated Student");
            BAIS3150.Close();
        }
        static void Main(string[] args)
        { char runAgain;
            string user;
            Console.Write("Please enter your username : ");
            user = Console.ReadLine();
            Console.Write("Please enter database password : ");
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            do
            {        
            string select;
            Console.Write("\n1 = Add Program \n2 = Get Programs \n3 = Get Program \n4 = Add Student \n5 = Get Student By Program Code\n6 = Update Student\n7 = Get Student \n8 = Delete Student\n\n Select: ");
            select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.Clear();
                        ExecuteNonQueryExample(user, pass); //watch for primary key error since the value is hard coded
                        break;
                    case "2":
                        Console.Clear();
                        ExecuteReaderExample(user, pass);
                        break;
                    case "3":
                        Console.Clear();
                        ExecuteScalarExample(user, pass);// sclar is returning one result (i think idk boys) A Scalar is simply a variable that holds an individual value. 
                        break;
                    case "4":
                        Console.Clear();
                        ExecuteAddStudent(user, pass);
                        break;
                    case "5":
                        Console.Clear();
                        ExecuteGetStudentByProgramCode(user, pass);
                        break;
                    case "6":
                        Console.Clear();
                        ExecuteUpdateStudent(user, pass);
                        break;
                    case "7":
                        ExecuteGetStudent(user, pass);
                        break;
                    case "8":
                        Console.Clear();
                        ExecuteDeleteStudent(user, pass);
                        break;
                    case "9":
                        //Domain Test
                        //--------------
                        //Student
                        //--------------
                        bool Success;
                        Student AcceptedStudent = new Student
                        {
                            StudentID = "SAMPLE3355",
                            FirstName = "Sample  Nam5e5",
                            LastName = "Sample  Nam544e55",
                            Email = "sample@7.com5"
                        };
                        string programCode = "BAIST";
                        Console.WriteLine($"{AcceptedStudent.StudentID}");
                        Console.WriteLine($"{AcceptedStudent.FirstName}");
                        Console.WriteLine($"{AcceptedStudent.LastName}");
                        Console.WriteLine($"{AcceptedStudent.Email}");
                        Students studentManager = new Students();
                        Success = studentManager.AddStudent(AcceptedStudent, programCode);
                        Console.WriteLine(Success);
                        break;
                    case "10":
                        //BCS
                        //ENROLL STUDENT
                        bool Confirmation;
                        Student AcceptedStudent2 = new Student
                        {
                            StudentID = "1BCS Ex1",
                            FirstName = "1BCS  Nam5e51",
                            LastName = "1BCS  Nam5414e55",
                            Email = "3BCS@7.co1m5"
                        };
                        BCS RequestDirector = new BCS();
                        Confirmation = RequestDirector.EnrollStudent(AcceptedStudent2, "PHOT");
                        Console.WriteLine(Confirmation);
                        AcceptedStudent2 = RequestDirector.FindStudent("123456789");
                        Console.WriteLine(AcceptedStudent2.FirstName,AcceptedStudent2.LastName,AcceptedStudent2.Email);
                        break;
                    case "11":
                        //UI TEST
                        //ENROLLS STUDENTS
                        bool Confirm;
                        Student AcceptedStudentUI = new Student
                        {
                            StudentID = "UISTudID",
                            FirstName = "UI FirstName",
                            LastName = "UI LastName",
                            Email = "UI@email.com"
                        };
                        string programCode1 = "BAIST";
                        BCS requesterDirectorUI = new BCS();
                        Confirm = requesterDirectorUI.EnrollStudent(AcceptedStudentUI, programCode1);
                        Console.WriteLine(Confirm);
                        break;
                    case "12":
                        Student student;
                        Students students = new Students();
                        student = students.GetStudent("123456789");
                        Console.WriteLine(student.FirstName);
                        Console.WriteLine(student.LastName);
                        Console.WriteLine(student.Email);
                        break;
                    case "13":
                        Students students1 = new Students();
                        List<Student> studentList = new List<Student>();
                        studentList = students1.GetStudentByProgramCode("BAIST");
                        foreach (Student stud in studentList)
                        {
                            Console.WriteLine($"{ stud.StudentID}, { stud.FirstName}, { stud.LastName}, { stud.Email}");
                        }
                        break;
                    default: ExecuteNonQueryExample(user, pass);
                    break;
                }
                Console.Write("Run again? (Y/y)");
                runAgain = char.Parse(Console.ReadLine());
                Console.Clear();
            } while (runAgain == 'y' || runAgain =='Y') ;
        }
    }
}
