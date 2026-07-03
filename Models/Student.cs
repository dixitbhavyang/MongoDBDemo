using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBDemo.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("city")]
        public string City { get; set; } = null!;

        [BsonElement("score")]
        public double Score { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}