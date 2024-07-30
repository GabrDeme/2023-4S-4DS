using minimalAPIMongo.Domains;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace minimalAPIMongo.ViewModels
{
    public class OrderViewModels
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? OrderId { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        //referência para que eu consiga cadastrar um pedido com os produtos
        [BsonElement("productId")]
        [JsonIgnore]
        public List<string>? ProductId { get; set; }


        //referência para quando eu listar os pedidos venham os dados de cada produto
        public List<Product>? Products { get; set; }

        //referência para que eu consiga cadastrar um pedido com os cliente
        [BsonElement("clientId")]
        [JsonIgnore]
        public List<string>? ClientId { get; set; }
    }
}
