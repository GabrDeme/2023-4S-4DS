using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimalAPIMongo.Domains
{
    public class Product
    {
        [BsonId]//define que esta prop é id do objeto

        //define o nome do campo no MongoDb como "_id" e o tipo como "ObjectId"
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? ProductId { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("price")]
        public float Price { get; set; }

        //configuração para alterar o fato do código fugir do benefício do bd noSql de ter mais 
        //adiciona um dicionário para atributos adicionais

        public Dictionary<string, string>? AdditionalAttribuites { get; set; }

        /// <summary>
        /// Ao ser instanciado um obj da calsse Product, o atributo AdditionalAtribuites já virá com um novo dicionpario, portanto estará habilitado para adicionar mais atributos
        /// </summary>
        public Product()
        {
            AdditionalAttribuites = new Dictionary<string, string>();
        }
    }
}
