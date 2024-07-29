using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }
        
        [BsonElement("password")]
        public string? Password { get; set; }

        public Dictionary<string, string> AdditionalAttribuites { get; set; }

        public User()
        { 
            AdditionalAttribuites = new Dictionary<string, string>(); 
        }
    }
}
