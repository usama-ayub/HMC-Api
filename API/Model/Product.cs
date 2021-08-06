using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace API.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
         public string Description { get; set; }
        [BsonElement]
         public string Price { get; set; }
        [BsonElement]
         public string Tags { get; set; }
        [BsonElement]
        public MongoDBRef CountryId { get; set; }
        [BsonElement]
         public MongoDBRef CityId { get; set; }
        [BsonElement]
         public MongoDBRef CategoryId { get; set; }
        [BsonElement]
         public MongoDBRef UserId { get; set; }
        [BsonElement]
        public bool Active { get; set; }
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}