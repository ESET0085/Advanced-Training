using Microsoft.AspNetCore.Mvc;
using Online_Product_Inventory_Management_System.Models;
using Online_Product_Inventory_Management_System.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Product_Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _productRepo.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();
            await _productRepo.UpdateAsync(product);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
