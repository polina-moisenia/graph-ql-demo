using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsageHistory.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UsageId { get; set; }
        public string AuthorId { get; set;}
        public string UserText { get; set; }
        public int Rate { get; set; }
    }
}