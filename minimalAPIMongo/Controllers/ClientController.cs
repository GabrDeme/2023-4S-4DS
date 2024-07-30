using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Service;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<User> _user;
        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var client = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            try
            {
                var existingClient = await _client.Find(client => client.UserId == client.UserId).FirstOrDefaultAsync();

                if (existingClient != null)
                {
                    return BadRequest("Client already exists.");
                }

                await _client.InsertOneAsync(client);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(string id)
        {
            try
            {
                var client = await _client.Find(x => x.ClientId == id).FirstOrDefaultAsync();
                return client == null ? NotFound() : Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Update(Client client)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.ClientId, client.ClientId);
                await _client.ReplaceOneAsync(filter, client);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpDelete]
        //public async Task<ActionResult<Client>> Delete(string id)
        //{
        //    try
        //    {
        //        var filter = Builders<Client>.Filter.Eq(x => x.ClientId, id);
        //        await _client.DeleteOneAsync(filter);
        //        return Ok(id);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
    }
}
