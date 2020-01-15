using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsageHistory.Models
{
    public class Usage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UsageId { get; set; }
        public string MovieId { get; set;}
        public string UserId { get; set; }
    }
}