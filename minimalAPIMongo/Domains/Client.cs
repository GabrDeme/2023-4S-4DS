using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userId"), BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("cpf")]
        public string? CPF { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }


        [BsonElement("AdditionalAtribuites")]
        public Dictionary<string, string> AdditionalAttribuites{ get; set; }

        public Client() 
        { 
            AdditionalAttribuites = new Dictionary<string, string>();
        }
    }
}
