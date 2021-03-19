using ClubBAISTPrototype.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.DAL
{
    public class PlayerScores
    {
        public int InsertGolfGame(GolfGame newGolfGame, string user, string password)
        {
            bool sqlError = false;
            int saleNumber = 0;


            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            SqlConnection ClubBaistConnection = new SqlConnection(configuration.GetConnectionString("BAIS3230"));
            ClubBaistConnection.Open();
            //  SqlTransaction sqlTransaction = ClubBaistConnection.BeginTransaction();

            SqlCommand AddGolfGameCommand = new SqlCommand()
            {
                CommandText = "AddGame",
                CommandType = CommandType.StoredProcedure,
                Connection = ClubBaistConnection,
                // Transaction = sqlTransaction
            };

            SqlParameter GolfGameDate = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@GolfGameDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newGolfGame.GolfGameDate
            };
            AddGolfGameCommand.Parameters.Add(GolfGameDate);
            SqlParameter timeSubmitted = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TimeSubmitted",
                SqlDbType = SqlDbType.Date,
                SqlValue = DateTime.Now
            };
            AddGolfGameCommand.Parameters.Add(timeSubmitted);
            SqlParameter golfCourse = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@GolfCourse",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newGolfGame.GolfCourse
            };
            AddGolfGameCommand.Parameters.Add(golfCourse);

            SqlParameter courseRating = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CourseRating",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.CourseRating
            };
            AddGolfGameCommand.Parameters.Add(courseRating);
            SqlParameter slopeRating = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@SlopeRating",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.SlopeRating
            };
            AddGolfGameCommand.Parameters.Add(slopeRating);
            SqlParameter totalScore = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TotalScore",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.TotalScore
            };
            AddGolfGameCommand.Parameters.Add(totalScore);
            SqlParameter memberNumber = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.MemberNumber
            };
            AddGolfGameCommand.Parameters.Add(memberNumber);
            SqlParameter GolfGameID = new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
                ParameterName = "@GolfGameID",
                SqlDbType = SqlDbType.Int
            };
            AddGolfGameCommand.Parameters.Add(GolfGameID);
            try
            {
                AddGolfGameCommand.ExecuteNonQuery();
                saleNumber = (int)AddGolfGameCommand.Parameters["@GolfGameID"].Value;
                if (saleNumber == -1)
                {
                    throw new Exception("Failed to add game");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"AddGame Error - {e}");
                // sqlTransaction.Rollback();
                sqlError = true;
            }
            if (!sqlError)
            {
                newGolfGame.holeList.ForEach(saleItem =>
                {
                    saleItem.GolfRoundID = saleNumber;

                    SqlCommand addSaleItemCommand = new SqlCommand()
                    {
                        CommandText = "AddGameHole",
                        CommandType = CommandType.StoredProcedure,
                        Connection = ClubBaistConnection,
                        // Transaction = sqlTransaction
                    };

                    SqlParameter ItemCode = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@HoleNumber",
                        SqlDbType = SqlDbType.Char,
                        SqlValue = saleItem.HoleNumber
                    };
                    addSaleItemCommand.Parameters.Add(ItemCode);
                    SqlParameter SaleNumber = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@GolfGameID",
                        SqlDbType = SqlDbType.Int,
                        SqlValue = saleItem.GolfRoundID
                    };
                    addSaleItemCommand.Parameters.Add(SaleNumber);

                    SqlParameter Quantity = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@Score",
                        SqlDbType = SqlDbType.Int,
                        SqlValue = saleItem.Score
                    };
                    addSaleItemCommand.Parameters.Add(Quantity);

                    try
                    {
                        addSaleItemCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Add Game Hole Error - {e}");
                        //  sqlTransaction.Rollback();
                        sqlError = true;
                    }
                });
            }
            if (!sqlError)
            {
                // sqlTransaction.Commit();
            }
            ClubBaistConnection.Close();
            return saleNumber;
        }
        public List<int> GetLast20Scores(int memberNumber, string user, string password)
        {
            List<int> totalScoreList;

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            SqlConnection ClubBaistConnection = new SqlConnection(configuration.GetConnectionString("BAIS3230"));
            ClubBaistConnection.Open();
            SqlCommand UpdateLast20Command = new SqlCommand();


            SqlCommand Last20Command = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetLast20Scores"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = memberNumber
            };

            Last20Command.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ApplicationReader;
            ApplicationReader = Last20Command.ExecuteReader();
            totalScoreList = new List<int>();
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
                        int newScore;
                        newScore = int.Parse(ApplicationReader.GetValue("TotalScore").ToString());
                        totalScoreList.Add(newScore);
                    }

                }
            }
            ApplicationReader.Close();
            ClubBaistConnection.Close();
            return totalScoreList;
        }
        public decimal GetHandicap(int memberNumber, string user, string password)
        {
            decimal handicap =0;

          
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            SqlConnection ClubBaistConnection = new SqlConnection(configuration.GetConnectionString("BAIS3230"));
            ClubBaistConnection.Open();
            SqlCommand UpdateMACommand = new SqlCommand();


            SqlCommand MACommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetHandicapIndex"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = memberNumber
            };

            MACommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ApplicationReader;
            ApplicationReader = MACommand.ExecuteReader();
       
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
                      
                        handicap = decimal.Parse(ApplicationReader.GetValue("HandicapIndex").ToString());
                      
                    }

                }
            }
            ApplicationReader.Close();
            ClubBaistConnection.Close();
            return handicap;
        }
        public string GetMemberName(int memberNumber, string user, string password)
        {
            string membername = "";

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            SqlConnection ClubBaistConnection = new SqlConnection(configuration.GetConnectionString("BAIS3230"));
            ClubBaistConnection.Open();
            SqlCommand UpdateMACommand = new SqlCommand();


            SqlCommand MACommand = new SqlCommand
            {
                Connection = ClubBaistConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetMemberName"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = memberNumber
            };

            MACommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ApplicationReader;
            ApplicationReader = MACommand.ExecuteReader();

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

                        membername =ApplicationReader.GetValue("MemberName").ToString();

                    }

                }
            }
            ApplicationReader.Close();
            ClubBaistConnection.Close();
            return membername;
        }


    }
}
