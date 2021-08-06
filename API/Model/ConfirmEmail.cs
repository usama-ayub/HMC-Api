using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model
{
    public class ConfirmEmail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string Link { get; set; }
        [BsonElement]
        public bool Active { get; set; }
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}