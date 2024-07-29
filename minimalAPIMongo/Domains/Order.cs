using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? OrderId { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        public Dictionary<string, string> AdditionalAttribuites { get; set; }

        public Order()
        {
            AdditionalAttribuites = new Dictionary<string, string>();
        }
    }
}
