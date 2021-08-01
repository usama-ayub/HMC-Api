using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string UserName { get; set; }
        [BsonElement]
        public string Adress { get; set; }
        [BsonElement]
        public string ContactNumber { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public byte[] PasswordHash { get; set; }
        [BsonElement]
        public byte[] PasswordSalt { get; set; }
        [BsonElement]

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        [BsonElement]
        public Boolean IsActive { get; set; }
    }
}