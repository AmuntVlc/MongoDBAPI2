using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDBAPI2.IU.Models
{
    public class Libro

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
    }
}
