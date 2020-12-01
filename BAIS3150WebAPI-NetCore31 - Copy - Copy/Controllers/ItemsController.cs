using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using BAIS3150WebAPI_NetCore31.AsianModels;

namespace BAIS3150WebAPI_NetCore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // GET: api/<ItemsController>
        [HttpGet]
        public List<Item> Get()
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand GetItemCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItems"
            };

            SqlDataReader AGetCommandDataReader;
        
            AGetCommandDataReader = GetItemCommand.ExecuteReader();

            List<Item> ExampleItems = new List<Item>();

            if (AGetCommandDataReader.HasRows)
            {
                while (AGetCommandDataReader.Read())
                {
                    Item ExampleItem = new Item
                    {
                        ItemNumber = (int)AGetCommandDataReader["ItemNumber"],
                        Description = AGetCommandDataReader["Description"].ToString(),
                        UnitPrice = (decimal)AGetCommandDataReader["UnitPrice"]
                    };
                    ExampleItems.Add(ExampleItem);

                    
                }
            }
            AGetCommandDataReader.Close();
            BAIS3150.Close();
            return ExampleItems;
        }

        // GET api/<ItemsController>/5
        [HttpGet("{itemNumber}")]
        public Item Get(int itemNumber)
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand GetItemCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem"
            };

            SqlParameter AGetCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = itemNumber
            };
            GetItemCommand.Parameters.Add(AGetCommandParameter);

            SqlDataReader AGetCommandDataReader;
            AGetCommandDataReader = GetItemCommand.ExecuteReader();

            Item ExampleItem = new Item();

            if (AGetCommandDataReader.HasRows)
            {
                AGetCommandDataReader.Read();

                ExampleItem.ItemNumber = itemNumber;
                ExampleItem.Description = (string)AGetCommandDataReader["Description"];
                ExampleItem.UnitPrice = (decimal)AGetCommandDataReader["UnitPrice"];
            }
       
        AGetCommandDataReader.Close();
            BAIS3150.Close();
            return ExampleItem;

        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item exampleItem)
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand PostItemCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddItem"
            };

            SqlParameter AGetCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            PostItemCommand.Parameters.Add(AGetCommandParameter);

            AGetCommandParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            PostItemCommand.Parameters.Add(AGetCommandParameter);

            PostItemCommand.ExecuteNonQuery();

        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item exampleItem)
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand UpdateItemCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateItem"
            };

            SqlParameter UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);

            UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);

            UpdateItemParameter = new SqlParameter
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.ItemNumber
            };
            UpdateItemCommand.Parameters.Add(UpdateItemParameter);

            UpdateItemCommand.ExecuteNonQuery();
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{itemNumber}")]
        public void Delete(int itemNumber)
        {
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info=False; Database=ihugya1;User ID=ihugya1;Password=SimpCord101;server=dev1.baist.ca;";
            BAIS3150.Open();

            SqlCommand DeleteItemCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem"
            };

            SqlParameter DeleteItemParameter = new SqlParameter
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = itemNumber
            };
            DeleteItemCommand.Parameters.Add(DeleteItemParameter);

            DeleteItemCommand.ExecuteNonQuery();

        }
    }
}
