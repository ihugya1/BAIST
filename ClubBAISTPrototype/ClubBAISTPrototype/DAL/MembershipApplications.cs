using ClubBAISTPrototype.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.DAL
{
    public class MembershipApplications
    {
        public MembershipApplication GetMembershipApplication(int MembershipApplicationID, string user, string password)
        {
            MembershipApplication membershipApplication = new MembershipApplication();

            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand UpdateMACommand = new SqlCommand();

            SqlCommand GetMACommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetMembershipApplication"
            };


            SqlParameter GetMAParameter = new SqlParameter
            {
                ParameterName = "@MembershipApplicationID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MembershipApplicationID
            };
            GetMACommand.Parameters.Add(GetMAParameter);
            SqlDataReader GetMAReader;
            GetMAReader = GetMACommand.ExecuteReader();


            if (GetMAReader.HasRows)
            {

                while (GetMAReader.Read())
                {
                    membershipApplication.MembershipApplicationID = int.Parse(GetMAReader.GetValue("MembershipApplicationID").ToString());
                    membershipApplication.FirstName = GetMAReader.GetValue("FirstName").ToString();
                    membershipApplication.LastName = GetMAReader.GetValue("LastName").ToString();
                    membershipApplication.Occupation = GetMAReader.GetValue("Occupation").ToString();
                    membershipApplication.CompanyName = GetMAReader.GetValue("CompanyName").ToString();
                    membershipApplication.HomeAddress = GetMAReader.GetValue("HomeAddress").ToString();
                    membershipApplication.CompanyAddress = GetMAReader.GetValue("CompanyAddress").ToString();
                    membershipApplication.HomePostalCode = GetMAReader.GetValue("HomePostalCode").ToString();
                    membershipApplication.CompanyPostalCode = GetMAReader.GetValue("CompanyPostalCode").ToString();
                    membershipApplication.HomePhone = GetMAReader.GetValue("HomePhone").ToString();
                    membershipApplication.CompanyPhone = GetMAReader.GetValue("CompanyPhone").ToString();
                    membershipApplication.HomeAlternatePhone = GetMAReader.GetValue("HomeAlternatePhone").ToString();
                    membershipApplication.Email = GetMAReader.GetValue("Email").ToString();
                    membershipApplication.DateOfBirth = DateTime.Parse(GetMAReader.GetValue("DateOfBirth").ToString());
                    membershipApplication.DateCompleted = DateTime.Parse(GetMAReader.GetValue("DateCompleted").ToString());
                    membershipApplication.ShareholderName1 = GetMAReader.GetValue("ShareholderName1").ToString();
                    membershipApplication.ShareholderName2 = GetMAReader.GetValue("ShareholderName2").ToString();

                }
                ClubBaistConnection.Close();
            }
            ClubBaistConnection.Close();
            return membershipApplication;
        }

        public List<MembershipApplication> GetMembershipApplications(string searchParam, string user, string password)
        {
            List<MembershipApplication> membershipApplicationList;

            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand UpdateMACommand = new SqlCommand();


            SqlCommand MACommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetMembershipApplications"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@SearchParam",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam.ToUpper()
            };

            MACommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader GetMAReader;
            GetMAReader = MACommand.ExecuteReader();
            membershipApplicationList = new List<MembershipApplication>();
            if (GetMAReader.HasRows)
            {
                Console.WriteLine("Columns:");
                Console.WriteLine("--------");
                for (int index = 0; index < GetMAReader.FieldCount; index++)
                {
                    Console.WriteLine(GetMAReader.GetName(index));
                }
                Console.WriteLine("Values:");
                Console.WriteLine("-------");
                for (int index = 0; index < GetMAReader.FieldCount; index++)
                {
                    while (GetMAReader.Read())
                    {
                        MembershipApplication membershipApplication = new MembershipApplication();
                        membershipApplication.MembershipApplicationID = int.Parse(GetMAReader.GetValue("MembershipApplicationID").ToString());
                        membershipApplication.FirstName = GetMAReader.GetValue("FirstName").ToString();
                        membershipApplication.LastName = GetMAReader.GetValue("LastName").ToString();
                        membershipApplication.Occupation = GetMAReader.GetValue("Occupation").ToString();
                        membershipApplication.CompanyName = GetMAReader.GetValue("CompanyName").ToString();
                        membershipApplication.HomeAddress = GetMAReader.GetValue("HomeAddress").ToString();
                        membershipApplication.CompanyAddress = GetMAReader.GetValue("CompanyAddress").ToString();
                        membershipApplication.HomePostalCode = GetMAReader.GetValue("HomePostalCode").ToString();
                        membershipApplication.CompanyPostalCode = GetMAReader.GetValue("CompanyPostalCode").ToString();
                        membershipApplication.HomePhone = GetMAReader.GetValue("HomePhone").ToString();
                        membershipApplication.CompanyPhone = GetMAReader.GetValue("CompanyPhone").ToString();
                        membershipApplication.HomeAlternatePhone = GetMAReader.GetValue("HomeAlternatePhone").ToString();
                        membershipApplication.Email = GetMAReader.GetValue("Email").ToString();
                        membershipApplication.DateOfBirth = DateTime.Parse(GetMAReader.GetValue("DateOfBirth").ToString());
                        membershipApplication.DateCompleted = DateTime.Parse(GetMAReader.GetValue("DateCompleted").ToString());
                        membershipApplication.ShareholderName1 = GetMAReader.GetValue("ShareholderName1").ToString();
                        membershipApplication.ShareholderName2 = GetMAReader.GetValue("ShareholderName2").ToString();
                        membershipApplicationList.Add(membershipApplication);

                    }

                }
            }
            GetMAReader.Close();
            ClubBaistConnection.Close();
            return membershipApplicationList;
        }
        public bool InsertMembershipApplication(MembershipApplication newMembershipApplication, string user, string password)
        {
            bool sqlError = false;
            Console.WriteLine("InsertMembershipApplication");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand UpdateStudentCommand = new SqlCommand();
            SqlCommand addMembershipApplicationCommand = new SqlCommand()
            {
                CommandText = "InsertMembershipApplication",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
            };
            SqlParameter FirstName = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.FirstName
            };
            addMembershipApplicationCommand.Parameters.Add(FirstName);
            SqlParameter LastName = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.LastName
            };
            addMembershipApplicationCommand.Parameters.Add(LastName);
            SqlParameter Status = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ApplicationStatus",
                SqlDbType = SqlDbType.Char,
                SqlValue = newMembershipApplication.Status
            };
            addMembershipApplicationCommand.Parameters.Add(Status);
            SqlParameter Occupation = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Occupation",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.Occupation
            };
            addMembershipApplicationCommand.Parameters.Add(Occupation);
            SqlParameter CompanyName = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CompanyName",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.CompanyName
            };
            addMembershipApplicationCommand.Parameters.Add(CompanyName);
            SqlParameter HomeAddress = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@HomeAddress",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.HomeAddress
            };
            addMembershipApplicationCommand.Parameters.Add(HomeAddress);
            SqlParameter CompanyAddress = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CompanyAddress",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.CompanyAddress
            };
            addMembershipApplicationCommand.Parameters.Add(CompanyAddress);
            SqlParameter HomePostalCode = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@HomePostalCode",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.HomePostalCode
            };
            addMembershipApplicationCommand.Parameters.Add(HomePostalCode);
            SqlParameter CompanyPostalCode = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CompanyPostalCode",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.CompanyPostalCode
            };
            addMembershipApplicationCommand.Parameters.Add(CompanyPostalCode);
            SqlParameter HomePhone = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@HomePhone",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.HomePhone
            };
            addMembershipApplicationCommand.Parameters.Add(HomePhone);
            SqlParameter CompanyPhone = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CompanyPhone",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.CompanyPhone
            };
            addMembershipApplicationCommand.Parameters.Add(CompanyPhone);
            SqlParameter HomeAlternatePhone = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@HomeAlternatePhone",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.HomeAlternatePhone
            };
            addMembershipApplicationCommand.Parameters.Add(HomeAlternatePhone);
            SqlParameter Email = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Email",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.Email
            };
            addMembershipApplicationCommand.Parameters.Add(Email);
            SqlParameter DateOfBirth = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@DateOfBirth",
                SqlDbType = SqlDbType.Date,
                SqlValue = newMembershipApplication.DateOfBirth
            };
            addMembershipApplicationCommand.Parameters.Add(DateOfBirth);
            SqlParameter DateCompleted = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@DateCompleted",
                SqlDbType = SqlDbType.Date,
                SqlValue = newMembershipApplication.DateCompleted
            };
            addMembershipApplicationCommand.Parameters.Add(DateCompleted);
            SqlParameter ShareholderName1 = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareholderName1",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.ShareholderName1
            };
            addMembershipApplicationCommand.Parameters.Add(ShareholderName1);
            SqlParameter ShareholderName2 = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@ShareholderName2",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newMembershipApplication.ShareholderName2
            };
            addMembershipApplicationCommand.Parameters.Add(ShareholderName2);

            try
            {
                addMembershipApplicationCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"addMembershipApplication Error - {e}");
                sqlError = true;
            }
            ClubBaistConnection.Close();
            return sqlError;
        }
        public bool ApproveMembershipApplication(int membershipApplicationID, string user, string password)
        {
            bool Success = true;
            Console.WriteLine("ApproveMembershipAppliction ");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand approvalMembershipAppliction = new SqlCommand()
            {
                CommandText = "ApproveMembershipApplication",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
            };
            SqlParameter StandingTeeTimeID = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MembershipApplicationID",
                SqlDbType = SqlDbType.Int,
                SqlValue = membershipApplicationID
            };
            approvalMembershipAppliction.Parameters.Add(StandingTeeTimeID);
            try
            {
                approvalMembershipAppliction.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"approvalMembershipAppliction Error - {e}");
                Success = false;
            }
            ClubBaistConnection.Close();
            return Success;
        }
        public bool RejectMembershipApplication(int membershipApplicationID, string user, string password)
        {
            bool Success = true;
            Console.WriteLine("RejectMembershipAppliction ");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            SqlCommand approvalMembershipAppliction = new SqlCommand()
            {
                CommandText = "RejectMembershipApplication",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
            };
            SqlParameter MembershipApplicationID = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MembershipApplicationID",
                SqlDbType = SqlDbType.Int,
                SqlValue = membershipApplicationID
            };
            approvalMembershipAppliction.Parameters.Add(MembershipApplicationID);
            try
            {
                approvalMembershipAppliction.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"RejectMembershipAppliction Error - {e}");
                Success = false;
            }
            ClubBaistConnection.Close();
            return Success;
        }
    }
}
