using ClubBAISTPrototype.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.DAL
{
    public class StandingTeeTimes
    {
        public bool InsertStandingTeeTimeRequest(StandingTeeTime newStandingTeeTimeRequest, string user, string password)
        {
            bool sqlError = false;
            Console.WriteLine("InsertStandingTeeTimeRequest");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand addStandingTeeTimeRequestCommand = new SqlCommand()
            {
                CommandText = "InsertStandingTeeTimeRequest",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
            };
            SqlParameter ShareHolderNumberParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareHolderNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.ShareHolderNumber
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(ShareHolderNumberParam);
            SqlParameter MemberNumber2Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber2",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber2
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber2Param);
            SqlParameter MemberNumber3Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber3",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber3
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber3Param);
            SqlParameter MemberNumber4Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber4",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber4
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber4Param);
            SqlParameter ShareHolderNameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareHolderName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.ShareHolderName
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(ShareHolderNameParam);
            SqlParameter Member2NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member2Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member2Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member2NameParam);
            SqlParameter Member3NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member3Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member3Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member3NameParam);
            SqlParameter Member4NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member4Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member4Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member4NameParam);
            SqlParameter StartDateParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@StartDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newStandingTeeTimeRequest.DateStart.Date
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(StartDateParam);
            SqlParameter EndDateParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EndDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newStandingTeeTimeRequest.DateEnd.Date
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EndDateParam);
            SqlParameter TeeTimeTimeParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TeeTimeTime",
                SqlDbType = SqlDbType.Time,
                SqlValue = newStandingTeeTimeRequest.TeeTimeTime.TimeOfDay
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(TeeTimeTimeParam);
            SqlParameter EmployeeNameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EmployeeName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.EmployeeName
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EmployeeNameParam);
            SqlParameter RequestedDayOfWeekParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RequestedDayofWeek",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.RequestedDayOfWeek
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(RequestedDayOfWeekParam);
            SqlParameter EmployeeNumberParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EmployeeNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.EmployeeNumber
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EmployeeNumberParam);

            try
            {
                addStandingTeeTimeRequestCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"addStandingTeeTimeRequest Error - {e}");
                sqlError = true;
            }
            ClubBaistConnection.Close();
            return sqlError;
        }
        public bool ModifyStandingTeeTimeRequest(StandingTeeTime newStandingTeeTimeRequest, string user, string password)
        {
            bool sqlError = false;
            Console.WriteLine("ModifyStandingTeeTime");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand addStandingTeeTimeRequestCommand = new SqlCommand()
            {
                CommandText = "ModifyStandingTeeTime",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
            };
            SqlParameter StandingTeeTimeIDParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@StandingTeeTimeID",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.StandingTeeTimeID
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(StandingTeeTimeIDParam);
            SqlParameter ShareHolderNumberParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareHolderNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.ShareHolderNumber
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(ShareHolderNumberParam);
            SqlParameter MemberNumber2Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber2",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber2
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber2Param);
            SqlParameter MemberNumber3Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber3",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber3
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber3Param);
            SqlParameter MemberNumber4Param = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber4",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.MemberNumber4
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(MemberNumber4Param);
            SqlParameter ShareHolderNameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareHolderName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.ShareHolderName
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(ShareHolderNameParam);
            SqlParameter Member2NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member2Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member2Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member2NameParam);
            SqlParameter Member3NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member3Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member3Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member3NameParam);
            SqlParameter Member4NameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Member4Name",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.Member4Name
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(Member4NameParam);
            SqlParameter StartDateParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@StartDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newStandingTeeTimeRequest.DateStart.Date
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(StartDateParam);
            SqlParameter EndDateParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EndDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newStandingTeeTimeRequest.DateEnd.Date
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EndDateParam);
            SqlParameter TeeTimeTimeParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TeeTimeTime",
                SqlDbType = SqlDbType.Time,
                SqlValue = newStandingTeeTimeRequest.TeeTimeTime.TimeOfDay
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(TeeTimeTimeParam);
            SqlParameter EmployeeNameParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EmployeeName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newStandingTeeTimeRequest.EmployeeName
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EmployeeNameParam);
            SqlParameter RequestedDayOfWeekParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@RequestedDayofWeek",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.RequestedDayOfWeek
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(RequestedDayOfWeekParam);
            SqlParameter EmployeeNumberParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@EmployeeNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newStandingTeeTimeRequest.EmployeeNumber
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(EmployeeNumberParam);
            SqlParameter IsCancelledParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IsCancelled",
                SqlDbType = SqlDbType.Bit,
                SqlValue = newStandingTeeTimeRequest.IsCancelled
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(IsCancelledParam);
            SqlParameter IsApprovedParam = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IsApproved",
                SqlDbType = SqlDbType.Bit,
                SqlValue = newStandingTeeTimeRequest.IsApproved
            };
            addStandingTeeTimeRequestCommand.Parameters.Add(IsApprovedParam);

            try
            {
                addStandingTeeTimeRequestCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"addStandingTeeTimeRequest Error - {e}");
                sqlError = true;
            }
            ClubBaistConnection.Close();
            return sqlError;
        }
        public List<StandingTeeTime> GetStandingTeeTimeRequests(string user, string password)
        {
            List<StandingTeeTime> standingTeeTimeRequests;

            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand UpdateMACommand = new SqlCommand();


            SqlCommand MACommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStandingTeeTimes"
            };

            SqlDataReader ApplicationReader;
            ApplicationReader = MACommand.ExecuteReader();
            standingTeeTimeRequests = new List<StandingTeeTime>();
            if (ApplicationReader.HasRows)
            {
                Console.WriteLine("Columns:");
                Console.WriteLine("--------");
                for (int index = 0; index < ApplicationReader.FieldCount; index++)
                {
                    Console.WriteLine(ApplicationReader.GetName(index));
                }
                Console.WriteLine("Values:");
                Console.WriteLine("-------");
                for (int index = 0; index < ApplicationReader.FieldCount; index++)
                {
                    while (ApplicationReader.Read())
                    {
                        StandingTeeTime tee = new StandingTeeTime();
                      tee.StandingTeeTimeID = int.Parse(ApplicationReader.GetValue("StandingTeeTimeID").ToString());
                        tee.ShareHolderNumber = int.Parse(ApplicationReader.GetValue("ShareHolderNumber").ToString());
                      
                                        tee.MemberNumber2 = int.Parse(ApplicationReader.GetValue("MemberNumber2").ToString());
                        tee.MemberNumber3 = int.Parse(ApplicationReader.GetValue("MemberNumber3").ToString());


                        tee.MemberNumber4 = int.Parse(ApplicationReader.GetValue("MemberNumber4").ToString());
                       
                                     tee.ShareHolderName = ApplicationReader.GetValue("ShareholderName").ToString(); 

                                tee.Member2Name = ApplicationReader.GetValue("MemberName2").ToString();
                        
                                   tee.Member3Name = ApplicationReader.GetValue("MemberName3").ToString(); 
                             tee.Member4Name = ApplicationReader.GetValue("MemberName4").ToString(); 
                        tee.DateStart = DateTime.Parse(ApplicationReader.GetValue("StartDate").ToString()); 
                   
                                        tee.DateEnd = DateTime.Parse(ApplicationReader.GetValue("EndDate").ToString());
                        
                                   tee.TeeTimeTime = DateTime.Parse(ApplicationReader.GetValue("TeeTimeTime").ToString()); 
                     
                   
                                        tee.RequestedDayOfWeek = int.Parse(ApplicationReader.GetValue("RequestedDayOfWeek").ToString());
                        tee.RequestedDayOfWeek= tee.RequestedDayOfWeek - 1;

                    
                                   tee.IsApproved = bool.Parse(ApplicationReader.GetValue("IsApproved").ToString());
                        standingTeeTimeRequests.Add(tee);
       

                    }
                }
            }
                ApplicationReader.Close();
                    ClubBaistConnection.Close();
            return standingTeeTimeRequests;



        }
    }
}