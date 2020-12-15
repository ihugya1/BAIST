using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.DAL
{
    class Courses
    {
        public bool AddCourse(Course ANewCourse)
        {
          
            bool confirmation = true;



            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
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
