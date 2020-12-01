using BAIST3150RazorPagesNETCore31.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BAIST3150RazorPagesNETCore31.TechnicalServices
{
    public class DatabaseUsers
    {
        public DatabaseUser GetDatabaseUser()
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
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
