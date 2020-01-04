using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set;}
        public string Year { get; set; }
        public List<string> Genres { get; set; }
    }
}