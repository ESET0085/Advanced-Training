using AMI_Project.Models;
using AMI_Project_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsumerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.Consumers.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _unitOfWork.Consumers.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody] Consumer consumer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _unitOfWork.Consumers.AddAsync(consumer);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = consumer.ConsumerId }, consumer);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Consumer consumer)
        {
            if (id != consumer.ConsumerId) return BadRequest("ID mismatch");

            var existing = await _unitOfWork.Consumers.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Consumers.Update(consumer);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _unitOfWork.Consumers.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Consumers.Delete(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
