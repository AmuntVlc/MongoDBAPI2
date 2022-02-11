using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDBAPI2.Models
{
    public class Ciudad

    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("Name")]
        public string Nombre { get; set; } = null!;
     }
}
