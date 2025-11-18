using Microsoft.AspNetCore.Mvc;
using Online_Product_Inventory_Management_System.Models;
using Online_Product_Inventory_Management_System.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Product_Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public CategoriesController(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        
        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            await _categoryRepo.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Category category)
        {
            if (id != category.CategoryId) return BadRequest();
            await _categoryRepo.UpdateAsync(category);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
