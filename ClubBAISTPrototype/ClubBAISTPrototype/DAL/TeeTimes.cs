using ClubBAISTPrototype.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.DAL
{
    public class TeeTimes
    {
        public List<TeeTime> GetDailyTeeSheetByDay(DateTime searchParam,string user, string password)
        {
            List<TeeTime> itemList;


            Console.WriteLine("InsertStandTeeTimeRequest ");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            //  SqlTransaction sqlTransaction = ClubBaistConnection.BeginTransaction();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetDailyTeeSheet"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@TeeSheetDay",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam.ToString("yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
        };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            itemList = new List<TeeTime>();
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
                        TeeTime item = new TeeTime();
                        item.TeeTimeDateTime = DateTime.Parse(ASampleDataReader.GetValue("TeeTimeDateTime").ToString());
                        item.MemberNumber = int.Parse(ASampleDataReader.GetValue("MemberNumber").ToString());
                        item.NumPlayers = int.Parse(ASampleDataReader.GetValue("NumPlayers").ToString());
                        item.NumCarts = int.Parse(ASampleDataReader.GetValue("NumCarts").ToString());
                        item.EmployeeName = ASampleDataReader.GetValue("EmployeeName").ToString();
                        item.IsStandingTeeTime = bool.Parse(ASampleDataReader.GetValue("IsStandingTeeTime").ToString());
                        itemList.Add(item);

                    }

                }
            }
            ASampleDataReader.Close();
            ClubBaistConnection.Close();
            return itemList;
        }
    }
}
