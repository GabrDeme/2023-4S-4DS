using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsTest.Interfaces;
using ProductsTest.Context;
using ProductsTest.Repository;
using Microsoft.Extensions.Logging;
using ProductsTest.Domains;
using System.Net;

namespace ProductsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        private readonly ProductsTestContext _context;

        public ProductsController(ProductsTestContext context)
        {
            _productsRepository = new ProductsRepository();

            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            { 
                return Ok(_productsRepository.GetAll());
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Products searchedProduct = _productsRepository.GetById(id);

                return Ok(searchedProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Register(Products products)
        {
            try
            {
                _productsRepository.Register(products);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Guid id, Products product)
        {
            try
            {
                _productsRepository.Update(id, product);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
