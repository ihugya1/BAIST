using ABC_Hardware.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.DAL
{
    public class ABCSales
    {
        public int ProcessASale(Sale newSale)
        { bool sqlError = false ;
            int saleNumber = 0;
            
            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlTransaction sqlTransaction = BAIS3150.BeginTransaction();

            SqlCommand addSaleCommand = new SqlCommand()
            {
                CommandText = "AddSale",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150,
                Transaction = sqlTransaction
            };

            SqlParameter SaleDate = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@SaleDate",
                SqlDbType = SqlDbType.Date,
                SqlValue = newSale.SalesDate
            };
            addSaleCommand.Parameters.Add(SaleDate);

            SqlParameter CustomerID = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.Int,
                SqlValue = newSale.CustomerID
            };
            addSaleCommand.Parameters.Add(CustomerID);

            SqlParameter EmployeeID = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@SalesPersonID",
                SqlDbType = SqlDbType.Int,
                SqlValue = newSale.SalesPersonID
            };
            addSaleCommand.Parameters.Add(EmployeeID);

            SqlParameter SaleNumber = new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
                ParameterName = "@SalesNumber",
                SqlDbType = SqlDbType.Int
            };
            addSaleCommand.Parameters.Add(SaleNumber);
            try
            {
                addSaleCommand.ExecuteNonQuery();
                saleNumber = (int)addSaleCommand.Parameters["@SaleNumber"].Value;
                if (saleNumber == -1)
                {
                    throw new Exception("Failed to add sale");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"AddSale Error - {e}");
                sqlTransaction.Rollback();
                sqlError = true;
            }
            if (!sqlError)
            {
                newSale.SalesItems.ForEach(saleItem => {
                    saleItem.SaleNumber= saleNumber;

                    SqlCommand addSaleItemCommand = new SqlCommand()
                    {
                        CommandText = "AddSaleItem",
                        CommandType = CommandType.StoredProcedure,
                        Connection = BAIS3150,
                        Transaction = sqlTransaction
                    };

                    SqlParameter ItemCode = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@ItemCode",
                        SqlDbType = SqlDbType.Char,
                        SqlValue = saleItem.ItemCode
                    };
                    addSaleItemCommand.Parameters.Add(ItemCode);
                    SqlParameter SaleNumber = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@SalesNumber",
                        SqlDbType = SqlDbType.Int,
                        SqlValue = saleItem.SaleNumber
                    };
                    addSaleItemCommand.Parameters.Add(SaleNumber);

                    SqlParameter Quantity = new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@Quantity",
                        SqlDbType = SqlDbType.Int,
                        SqlValue = saleItem.Quantity
                    };
                    addSaleItemCommand.Parameters.Add(Quantity);

                    try
                    {
                        addSaleItemCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"AddSaleItem Error - {e}");
                        sqlTransaction.Rollback();
                        sqlError = true;
                    }
                });
            }
            if (!sqlError)
            {
                sqlTransaction.Commit();
            }
            BAIS3150.Close();
            return saleNumber;
        }
    }
}