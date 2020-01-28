using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reviews.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ReviewId { get; set; }
        public string MovieId { get; set; }
        public string AuthorId { get; set;}
        public string ReviewText { get; set; }
        public int Rate { get; set; }
    }
}