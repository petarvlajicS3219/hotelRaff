using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HotelNoSql.DbConfig.DbConfig;
using System.Text.Json;


namespace HotelNoSql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var collection = connectDB();
            var newRoom = collection.Find(x => x.Hrana == true).ToList();



            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
            foreach (HotelNoSql.Models.Soba item in newRoom)
            {

                string jsonString = JsonSerializer.Serialize(item);
                Console.WriteLine(jsonString);
            }


            //Console.WriteLine(newRoom);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
