using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Service;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");

        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var order = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult<Order>> Create(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();
                order.OrderId = orderViewModel.OrderId;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;
                
                var client = await _client.Find(x => x.ClientId == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound();
                }

                order.Client = client;
                await _order!.InsertOneAsync(order);
                return StatusCode(201, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.OrderId == id).FirstOrDefaultAsync();
                return order == null ? NotFound() : Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("clientId")]
        //public async Task<ActionResult<Order>> GetByClientId(string id)
        //{
        //    try
        //    {
        //        var order = await _order.Find(p => p.Client!.ClientId == id).FirstOrDefaultAsync();
        //        if (order == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(order);

        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult> Update(Order updatedOrder)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.OrderId, updatedOrder.OrderId);

                await _order.ReplaceOneAsync(filter, updatedOrder);

                return Ok();


            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Order>> Delete(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.OrderId, id);
                await _order.DeleteOneAsync(filter);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
