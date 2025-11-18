using AMI_Project.Models;
using AMI_Project_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffSlabController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TariffSlabController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var slabs = await _unitOfWork.TariffSlabs.GetAllAsync();
            return Ok(slabs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var slab = await _unitOfWork.TariffSlabs.GetByIdAsync(id);
            if (slab == null) return NotFound();
            return Ok(slab);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody] TariffSlab slab)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _unitOfWork.TariffSlabs.AddAsync(slab);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = slab.TariffSlabId }, slab);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] TariffSlab slab)
        {
            if (id != slab.TariffSlabId) return BadRequest("ID mismatch");

            var existing = await _unitOfWork.TariffSlabs.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.TariffSlabs.Update(slab);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _unitOfWork.TariffSlabs.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.TariffSlabs.Delete(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
