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
    public class Items
    {
        public bool AddItem(Item newItem) //parameters, camel casing
        {
            bool Success = true;
            bool isDeleted = false;
            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand AddItemCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            AddItemCommand.Connection = BAIS3150;
            AddItemCommand.CommandType = CommandType.StoredProcedure;
            AddItemCommand.CommandText = "AddItem";
            SqlParameter AddItemParameter;
            AddItemParameter = new SqlParameter //object initialization
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.ItemCode
            };
            AddItemCommand.Parameters.Add(AddItemParameter);
            AddItemParameter = new SqlParameter
            {
                ParameterName = "@ItemDescription",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.ItemDescription
            };
            AddItemCommand.Parameters.Add(AddItemParameter);
            AddItemParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.SmallMoney,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.UnitPrice
            };
            AddItemCommand.Parameters.Add(AddItemParameter);
            AddItemParameter = new SqlParameter
            {
                ParameterName = "@IsDeleted",
                SqlDbType = SqlDbType.Bit,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = isDeleted
            };
            AddItemCommand.Parameters.Add(AddItemParameter);
            AddItemParameter = new SqlParameter
            {
                ParameterName = "@QuantityOnHand",
                SqlDbType = SqlDbType.Int,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.QuantityOnHand
            };
            AddItemCommand.Parameters.Add(AddItemParameter);

            try
            {
                AddItemCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Success = false;
                Console.WriteLine(e);
                return Success;
            }
            Console.WriteLine("Success: Added Item");
            Success = true;
            BAIS3150.Close();
            return Success;
        }
        public List<Item> GetItemsBySearchParam(string searchParam)
        {
            List<Item> itemList;

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "SearchItems"
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@SearchParam",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = searchParam
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            itemList = new List<Item>();
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
                        Item item = new Item();
                        item.ItemCode = ASampleDataReader.GetValue("ItemCode").ToString();
                        item.ItemDescription = ASampleDataReader.GetValue("ItemDescription").ToString();
                        item.UnitPrice = decimal.Parse(ASampleDataReader.GetValue("UnitPrice").ToString());
                        item.QuantityOnHand = int.Parse(ASampleDataReader.GetValue("QuantityOnHand").ToString());
                        item.IsDeleted = bool.Parse(ASampleDataReader.GetValue("IsDeleted").ToString());
                        itemList.Add(item);

                    }

                }
            }
            ASampleDataReader.Close();
            BAIS3150.Close();
            return itemList;
        }
        public bool DeleteItem(string itemCode)
        {
            bool success = true;

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand DeleteItemCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            DeleteItemCommand.Connection = BAIS3150;
            DeleteItemCommand.CommandType = CommandType.StoredProcedure;
            DeleteItemCommand.CommandText = "DeleteItem";
            SqlParameter DeleteItemParameter;
            DeleteItemParameter = new SqlParameter //object initialization
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
            };
            DeleteItemCommand.Parameters.Add(DeleteItemParameter);
            try
            {
                DeleteItemCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
                return success;
                throw;
            }
            Console.WriteLine("Success: Delete Item");
            BAIS3150.Close();
            return success;
        }
        public Item GetItem(string itemCode)
        {
            Item item = new Item();

            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
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

                        item.ItemCode = ASampleDataReader.GetValue("ItemCode").ToString();
                        item.ItemDescription = ASampleDataReader.GetValue("ItemDescription").ToString();
                        item.UnitPrice = decimal.Parse(ASampleDataReader.GetValue("UnitPrice").ToString());
                        item.QuantityOnHand = int.Parse(ASampleDataReader.GetValue("QuantityOnHand").ToString());
                        item.IsDeleted = bool.Parse(ASampleDataReader.GetValue("IsDeleted").ToString());

                    }
                }
                BAIS3150.Close();
            }
            BAIS3150.Close();
            return item;
        }
        public bool UpdateItem(Item newItem)
        {
            bool success = true;
            ConfigurationBuilder DatabaseUsersBuilder = new ConfigurationBuilder();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();
            SqlCommand UpdateItemCommand = new SqlCommand(); // this is declaration and instantiation wooowwwww very cool
            UpdateItemCommand.Connection = BAIS3150;
            UpdateItemCommand.CommandType = CommandType.StoredProcedure;
            UpdateItemCommand.CommandText = "UpdateItem";
            SqlParameter UpdateItemParameter;
            UpdateItemParameter = new SqlParameter //object initialization
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.ItemCode
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);
            UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@ItemDescription",
                SqlDbType = SqlDbType.VarChar,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.ItemDescription
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);
            UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.SmallMoney,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.UnitPrice
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);
            UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@QuantityOnHand",
                SqlDbType = SqlDbType.Int,//this is a input parameter -> no need to input (10) or "size"
                Direction = ParameterDirection.Input,
                SqlValue = newItem.QuantityOnHand
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);

            try
            {
                UpdateItemCommand.ExecuteNonQuery();//not getting a result back 
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine(e);
                return success;
            }
            Console.WriteLine("Success: Added Item");
            success = true;
            BAIS3150.Close();
            return success;
        }


    }
}
