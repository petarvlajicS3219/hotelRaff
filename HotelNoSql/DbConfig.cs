using MongoDB.Driver;
using System;
using static HotelNoSql.Models.Soba;

namespace HotelNoSql.DbConfig
{
    public class DbConfig
    {

        public static MongoDB.Driver.IMongoCollection<HotelNoSql.Models.Soba> connectDB()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://petar:petar123@cluster0.eawtd.mongodb.net/PrvaBaza?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();
            var database = dbClient.GetDatabase("PrvaBaza");
            var sobe = database.GetCollection<HotelNoSql.Models.Soba>("Sobe");

            return sobe;

        }
    }
}
