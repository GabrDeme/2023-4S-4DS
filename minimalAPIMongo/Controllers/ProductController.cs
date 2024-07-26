using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Service;
using MongoDB.Bson;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Armazena os dados de acesso da collection
        /// </summary>
        private readonly IMongoCollection<Product> _product;

        /// <summary>
        /// Construtor que recebe como dependência o obj da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService">objeti da classe MongoDbService</param>
        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get() 
        {
            try
            { 
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product updatedProduct)
        {

            try
            {
                var product = await mongoDbService.GetAsync(id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                updatedProduct.Id = product.Id; 

                await mongoDbService.UpdateAsync(id, mongoDbService);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }




    }
}
