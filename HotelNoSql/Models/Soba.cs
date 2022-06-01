using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelNoSql.Models
{
    public class Soba
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string ime { get; set; }
        public int brojKreveta { get; set; }
        public string opis { get; set; }
        public bool miniBar { get; set; }
        public bool Hrana { get; set; }
        
        public float cena { get; set; }

    }
}
