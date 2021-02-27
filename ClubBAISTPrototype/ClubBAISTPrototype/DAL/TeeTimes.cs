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
        public void CreateDailySheet(DateTime searchParam,string user, string password)
        {
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            //  SqlTransaction sqlTransaction = ClubBaistConnection.BeginTransaction();
            SqlCommand CreateTimesCommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "CreateTimes"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@TeeSheetDay",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam.ToString("yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            };
            CreateTimesCommand.Parameters.Add(ASampleCommandParameter);
            try
            {
                CreateTimesCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine(searchParam);
                Console.WriteLine("Already exists");
            }
          
        }
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
            SqlParameter ASampleCommandParameter2 = new SqlParameter
            {
                ParameterName = "@TeeSheetDay",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam.ToString("yyyy-MM-dd",
               System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            };

            ASampleCommand.Parameters.Add(ASampleCommandParameter2);
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
                        item.TeeTimeDate = DateTime.Parse(ASampleDataReader.GetValue("TeeTimeDate").ToString());
                        item.TeeTimeTime = DateTime.Parse(ASampleDataReader.GetValue("TeeTimeTime").ToString());
                        item.TeeTimeDate = item.TeeTimeDate.Add(item.TeeTimeTime.TimeOfDay);
                        item.MemberNumber = ASampleDataReader.GetValue("MemberNumber") as int? ?? default(int);
                        item.NumPlayers = ASampleDataReader.GetValue("NumPlayers") as int? ?? default(int);
                        item.NumCarts = ASampleDataReader.GetValue("NumCarts") as int? ?? default(int);
                        item.EmployeeName = ASampleDataReader.GetValue("EmployeeName") as string;
                        item.IsStandingTeeTime = ASampleDataReader.GetValue("IsStandingTeeTime") as bool? ?? default(bool);
                        item.IsSpecialEvent = ASampleDataReader.GetValue("IsSpecialEvent") as bool? ?? default(bool);
                        itemList.Add(item);

                    }

                }
            }
            ASampleDataReader.Close();
            ClubBaistConnection.Close();
            return itemList;
        }
        public TeeTime GetTeeTime(DateTime searchParam,DateTime timeParam, string user, string password)
        {
           

            TeeTime item = new TeeTime();
            Console.WriteLine("GetTeeTime ");
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
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam.ToString("yyyy-MM-dd",
               System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
            };
            SqlParameter ASampleCommandParameter2 = new SqlParameter
            {
                ParameterName = "@TeeTimeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                SqlValue = timeParam.TimeOfDay
            };

            ASampleCommand.Parameters.Add(ASampleCommandParameter2);
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
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                    {
                       
                        item.TeeTimeDate = DateTime.Parse(ASampleDataReader.GetValue("TeeTimeDate").ToString());
                        item.TeeTimeTime = DateTime.Parse(ASampleDataReader.GetValue("TeeTimeTime").ToString());
                        item.TeeTimeDate = item.TeeTimeDate.Add(item.TeeTimeTime.TimeOfDay);
                        item.MemberNumber = ASampleDataReader.GetValue("MemberNumber") as int? ?? default(int);
                        item.NumPlayers = ASampleDataReader.GetValue("NumPlayers") as int? ?? default(int);
                        item.NumCarts = ASampleDataReader.GetValue("NumCarts") as int? ?? default(int);
                        item.EmployeeName = ASampleDataReader.GetValue("EmployeeName") as string;
                        item.IsStandingTeeTime = ASampleDataReader.GetValue("IsStandingTeeTime") as bool? ?? default(bool);
                        item.IsSpecialEvent = ASampleDataReader.GetValue("IsSpecialEvent") as bool? ?? default(bool);
                       

                    }

                }
            }
            ASampleDataReader.Close();
            ClubBaistConnection.Close();
            return item;
        }

    }

}
