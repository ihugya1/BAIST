using BAIST3150RazorPagesNETCore31.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration; // ConfigurationBuilder
using System.IO;                          // Directory
namespace BAIST3150RazorPagesNETCore31.TechnicalServices
{
    public class DatabaseUsers
    {
        public DatabaseUser GetDatabaseUser()
        {

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString =  DatabaseUsersConfiguration.GetConnectionString("BAIS3150");

            BAIS3150.Open();

            SqlCommand AGetCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetDatabaseUser"
            };
            SqlDataReader AGetCommandDataReader;
            AGetCommandDataReader = AGetCommand.ExecuteReader();

            DatabaseUser CurrentDatabaseUser = new DatabaseUser();

            if (AGetCommandDataReader.HasRows)
            {
                AGetCommandDataReader.Read();
                CurrentDatabaseUser.CurrentUser = (string)AGetCommandDataReader["CurrentUser"];
                CurrentDatabaseUser.SystemUser = (string)AGetCommandDataReader["SystemUser"];
                CurrentDatabaseUser.SessionUser = (string)AGetCommandDataReader["SessionUser"];
            }

            AGetCommandDataReader.Close();
            BAIS3150.Close();
            return CurrentDatabaseUser;
        }

    }
}
