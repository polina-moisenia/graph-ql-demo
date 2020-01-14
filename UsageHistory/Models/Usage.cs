using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using UsageHistory.Resolvers;

namespace UsageHistory.Models
{
    public class Usage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UsageId { get; set; }
        public string Title { get; set;}
        public string Year { get; set; }
        public List<string> Genres { get; set; }
    }
}