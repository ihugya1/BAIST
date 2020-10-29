using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.DAL
{
    class Courses
    {
        public bool AddCourse(Course ANewCourse)
        {
            bool confirmation = true;
      
            Console.WriteLine("Execute Add Course");
            string user;
            Console.Write("Please enter DB Name : ");
            user = Console.ReadLine();
            Console.Write("Please enter DB Password : ");
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand InsertCourseCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddCourse"
            };
            SqlParameter CourseIDParameter = new SqlParameter
            {
                ParameterName = "@CourseID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ANewCourse.CourseID
            };
            InsertCourseCommand.Parameters.Add(CourseIDParameter);
            SqlParameter HoursParameter = new SqlParameter
            {
                ParameterName = "@Hours",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ANewCourse.Hours
            };
            InsertCourseCommand.Parameters.Add(HoursParameter);
            SqlParameter Offering = new SqlParameter
            {
                ParameterName = "@Offering",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ANewCourse.Offering
            };
            InsertCourseCommand.Parameters.Add(Offering);

            try
            {
                InsertCourseCommand.ExecuteNonQuery();//not getting a result back 
                Console.WriteLine("Insert Course Sucessful");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failure: {e}");
                confirmation = false;
                return confirmation;
            }
            BAIS3150.Close();
            return confirmation;
        }
    }
}
