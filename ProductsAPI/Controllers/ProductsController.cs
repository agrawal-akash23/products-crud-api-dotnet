using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // ASP.NET Core DI container automatically injects IProductService here
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        // GET api/products/3
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> Create([FromBody]Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name)) return BadRequest("Product name is required.");

            var created = _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/products/3
        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody]Product product)
        {
            var updated = _productService.Update(id, product);
            if (updated == null) return NotFound($"Product with ID {id} not found.");

            return Ok(updated);
        }

        // DELETE api/products/3
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _productService.Delete(id);
            if (!deleted) return NotFound($"Product with ID {id} not found.");

            return NoContent(); // 204 - success, nothing to return
        }
    }
}
