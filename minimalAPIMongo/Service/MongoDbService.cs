using MongoDB.Driver;

namespace minimalAPIMongo.Service
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazena a configuração da aplicação
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Armazena uma referência ao MongoDb
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Recebe a config da aplicação como parâmetro
        /// </summary>
        /// <param name="configuration">objeto configuration</param>
        public MongoDbService(IConfiguration configuration) 
        { 
            //Atribui a config recebida em _configuration
            _configuration = configuration;

            //Obtém a string de conexão através do configuration
            var connectionString = _configuration.GetConnectionString("DbConnection");

            //Cria um obj MongoUrl que recebe como parâmetro a string de conexão
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client MongoClient para se conectar ao MongoDb
            var mongoClient = new MongoClient(mongoUrl);

            //Obtém a referência ao bd com o nome especificado no string de conexão
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);


        }
         public IMongoDatabase GetDatabase => _database;
    }
}
