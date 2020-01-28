using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reviews.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        [BsonElement("dob")]
        public string DOB { get; set; }
    }
}