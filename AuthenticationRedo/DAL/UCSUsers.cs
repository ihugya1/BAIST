using AuthenticationRedo.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationRedo.DAL
{
    public class UCSUsers
    {
        public UCSUser GetStudent(string email)
        {
            UCSUser ucsuser = new UCSUser();
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetUser",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = email
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
                        ucsuser.Email = email;
                        ucsuser.UserName = (string)ASampleDataReader["UserName"];
                        ucsuser.HashPass = (string)ASampleDataReader["HashPass"];
                        ucsuser.SaltPass = (string)ASampleDataReader["SaltPass"];
                        ucsuser.Role = (string)ASampleDataReader["Role"];
                        ucsuser.Created = (DateTime)ASampleDataReader["Created"];
                    }
                }
                BAIS3150.Close();
            }
            BAIS3150.Close();
            return ucsuser;
        }
    }
}
