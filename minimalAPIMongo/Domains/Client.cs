using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? ClientId { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("CPF")]
        public string? CPF { get; set; }

        [BsonElement("Phone")]
        public string? Phone { get; set; }

        [BsonElement("Adress")]
        public string? Adress { get; set; }

        public Dictionary<string, string> AdditionalAttribuites{ get; set; }

        public Client() 
        { 
            AdditionalAttribuites = new Dictionary<string, string>();
        }
    }
}
