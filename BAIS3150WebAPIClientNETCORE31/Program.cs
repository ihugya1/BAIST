using System;

using BAIS3150WebAPIClientNETCORE31.Domain;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net;

namespace BAIS3150WebAPIClientNETCORE31
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient WebAPIClient = new HttpClient())
            {
               
                MediaTypeWithQualityHeaderValue ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                WebAPIClient.DefaultRequestHeaders.Accept.Add(ContentType);
                WebAPIClient.BaseAddress = new Uri("http://localhost:49447/");
                HttpResponseMessage WebAPIResponseMessage;

                string WebAPIGetContent;
                string SerializedJson;
                StringContent WebAPIPostPutContent;

                JsonSerializerOptions Options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // default is false
                };


                //[HttpGet]
                Console.WriteLine("--------------");
                Console.WriteLine("HttpGet");
                Console.WriteLine("--------------");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items");
                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                List<Item> ExampleItems = JsonSerializer.Deserialize<List<Item>>(WebAPIGetContent,Options);

                foreach (var item in ExampleItems)
                {
                    Console.WriteLine("*");
                    Console.WriteLine(item.Description,item.ItemNumber,item.UnitPrice);
                    Console.WriteLine("*");
                }

                //[HttpGet("{itemNumber}")]
                Console.WriteLine("\n*********************");
                Console.WriteLine("HttpGet {itemNumber}");
                Console.WriteLine("*********************");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items/3");
                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                Item ExampleItem = JsonSerializer.Deserialize<Item>(WebAPIGetContent, Options);
                Console.WriteLine(ExampleItem.ItemNumber);
                Console.WriteLine(ExampleItem.Description);
                Console.WriteLine(ExampleItem.UnitPrice);


                //[HttpPost]
                Console.WriteLine("\n~~~~~~~~~~~~~~~~");
                Console.WriteLine("HttpPost");
                Console.WriteLine("~~~~~~~~~~~~~~~~");

                ExampleItem.ItemNumber = 999; //not need for identity column
                ExampleItem.Description = "HttpPost Insert Description";
                ExampleItem.UnitPrice = (decimal)1.11;

                string StringData = JsonSerializer.Serialize(ExampleItem);

                WebAPIPostPutContent = new StringContent(StringData, System.Text.Encoding.UTF8, "application/json");
                WebAPIResponseMessage = await WebAPIClient.PostAsync("/api/Items", WebAPIPostPutContent);


                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert not successful");
                }

                //[HttpPut("{itemNumber}")]
                Console.WriteLine("/////////////////////");
                Console.WriteLine("HttpPut {itemNumber}");
                Console.WriteLine("/////////////////////");

                ExampleItem.ItemNumber = 4;
                ExampleItem.Description = "HttpPut update description";
                ExampleItem.UnitPrice = (decimal)68.32;

                SerializedJson = JsonSerializer.Serialize(ExampleItem);
                WebAPIPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8, "application/json");
                WebAPIResponseMessage = await WebAPIClient.PutAsync("/api/Items/4", WebAPIPostPutContent);
                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + "update succesful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Update not succesful");
                }


                //[HttpDelete("{itemNumber}")]
                Console.WriteLine("--------------");
                Console.WriteLine("HttpDelete {itemNumber}");
                Console.WriteLine("--------------");
                WebAPIResponseMessage = await WebAPIClient.DeleteAsync("/api/Items/5");

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + "Delete succesful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + "Delete failed");
                }
            }
        }
    }
}
