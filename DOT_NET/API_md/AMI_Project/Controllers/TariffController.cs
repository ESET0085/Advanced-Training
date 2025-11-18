using AMI_Project.Models;
using AMI_Project_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TariffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tariffs = await _unitOfWork.Tariffs.GetAllAsync();
            return Ok(tariffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tariff = await _unitOfWork.Tariffs.GetByIdAsync(id);
            if (tariff == null) return NotFound();
            return Ok(tariff);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Tariff tariff)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _unitOfWork.Tariffs.AddAsync(tariff);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = tariff.TariffId }, tariff);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Tariff tariff)
        {
            if (id != tariff.TariffId) return BadRequest("ID mismatch");

            var existing = await _unitOfWork.Tariffs.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Tariffs.Update(tariff);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _unitOfWork.Tariffs.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Tariffs.Delete(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
