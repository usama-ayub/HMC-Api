using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace API.Model
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public MongoDBRef ProductId { get; set; }
        [BsonElement]
        public string PublicId { get; set; }
        [BsonElement]
        public string Url { get; set; }
        [BsonElement]
        public bool Main { get; set; }
        public bool Active { get; set; }
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}