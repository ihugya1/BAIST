﻿using ClubBAISTPrototype.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


            Console.WriteLine("InsertStandTeeTimeRequest ");
            SqlConnection ClubBaistConnection;
            ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            ClubBaistConnection.Open();
            //  SqlTransaction sqlTransaction = ClubBaistConnection.BeginTransaction();

            SqlCommand addSaleCommand = new SqlCommand()
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
            addSaleCommand.Parameters.Add(GolfGameDate);
            SqlParameter timeSubmitted = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TimeSubmitted",
                SqlDbType = SqlDbType.Date,
                SqlValue = DateTime.Now
            };
            addSaleCommand.Parameters.Add(timeSubmitted);
            SqlParameter golfCourse = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@GolfCourse",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = newGolfGame.GolfCourse
            };
            addSaleCommand.Parameters.Add(golfCourse);

            SqlParameter courseRating = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CourseRating",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.CourseRating
            };
            addSaleCommand.Parameters.Add(courseRating);
            SqlParameter slopeRating = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@SlopeRating",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.SlopeRating
            };
            addSaleCommand.Parameters.Add(slopeRating);
            SqlParameter totalScore = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@TotalScore",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.TotalScore
            };
            addSaleCommand.Parameters.Add(totalScore);
            SqlParameter memberNumber = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                SqlValue = newGolfGame.MemberNumber
            };
            addSaleCommand.Parameters.Add(memberNumber);
            SqlParameter GolfGameID = new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
                ParameterName = "@GolfGameID",
                SqlDbType = SqlDbType.Int
            };
            addSaleCommand.Parameters.Add(GolfGameID);
            try
            {
                addSaleCommand.ExecuteNonQuery();
                saleNumber = (int)addSaleCommand.Parameters["@GolfGameID"].Value;
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
    }
}