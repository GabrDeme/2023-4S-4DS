﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace minimalAPIMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
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
        public string? ClientId { get; set; }


        //referência para quando eu listar os pedidos venham os dados do cliente
        public Client? Client { get; set; }
    }
}
