using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Service;
using minimalAPIMongo.ViewModels;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                //Pista todos os pedidos da collection "Order"
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                //Percorre todos os itens da lista 
                foreach (var order in orders)
                {
                    //Verifica se existe uma lista de produtos para cada pedido
                    if (order.ProductId != null)
                    {
                        //Dentro da collection "Product" faz uma filtragem("Separa" os produtos que estão dentro do pedido e seleciona os ids dos produtos dentro da collecton, cujo id está presente a lista "order.ProductId")
                        var filter = Builders<Product>.Filter.In(p => p.ProductId, order.ProductId);

                        //Busca os produtos correspondentes ao pedido e adiciona em "order.Products" e traz as informações dos produtos
                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    //Busca e associa o cliente correspondente ao pedido
                    if (order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();

                order.OrderId = orderViewModel.OrderId;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;
              

                //Busca na collection de clientes um cliente com o clientId passado na requisição
                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                //Se não exisir
                if (client == null)
                {
                    return NotFound();
                }

                //Caso exista, atribua-se para a propriedade cliente do pedido o cliente buscado
                order.Client = client;

                //Cadastre o pedido na collection
                await _order.InsertOneAsync(order);

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

            // Busca por id um objeto específico
            var order = await _order.Find(p => p.OrderId == id).FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            // Populate client details if ClientId is not null
            if (!string.IsNullOrEmpty(order.ClientId))
            {
                order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
            }

            // Populate product details if ProductId list is not null or empty
            if (order.ProductId != null && order.ProductId.Any())
            {
                order.Products = await _product.Find(x => order.ProductId.Contains(x.Id)).ToListAsync();
            }

            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult> Update(string id, OrderViewModel updatedOrderViewModel)
        {
            try
            {
                var existingOrder = await _order.Find(x => x.OrderId == id).FirstOrDefaultAsync();
                if (existingOrder == null)
                {
                    return NotFound();
                }

                existingOrder.Date = updatedOrderViewModel.Date;
                existingOrder.Status = updatedOrderViewModel.Status;
                existingOrder.ClientId = updatedOrderViewModel.ClientId;
                existingOrder.ProductId = updatedOrderViewModel.ProductId;

                if (!string.IsNullOrEmpty(existingOrder.ClientId))
                {
                    existingOrder.Client = await _client.Find(x => x.Id == existingOrder.ClientId).FirstOrDefaultAsync();
                }

                if (existingOrder.ProductId != null && existingOrder.ProductId.Any())
                {
                    existingOrder.Products = await _product.Find(x => existingOrder.ProductId.Contains(x.Id)).ToListAsync();
                }

                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                await _order.ReplaceOneAsync(filter, existingOrder);

                return Ok(existingOrder);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(string id)
        {
            try
            {
                //Busca um objeto pelo id e deleta o mesmo
                var deleteResult = await _order.DeleteOneAsync(p => p.OrderId == id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
