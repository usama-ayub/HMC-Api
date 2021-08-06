using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace API.Model
{
    public class Favourite
    {        
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public MongoDBRef ProductId { get; set; }
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        
    }
}