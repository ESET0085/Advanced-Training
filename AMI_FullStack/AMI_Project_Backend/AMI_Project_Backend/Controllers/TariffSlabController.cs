using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffSlabController : ControllerBase
    {
        private readonly ITariffSlabRepository _tariffSlabRepository;

        public TariffSlabController(ITariffSlabRepository tariffSlabRepository)
        {
            _tariffSlabRepository = tariffSlabRepository;
        }

        [HttpGet("{tariffId}")]
        public async Task<IActionResult> GetByTariffId(int tariffId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var slabs = await _tariffSlabRepository.GetByTariffIdAsync(tariffId);

            var slabDtos = slabs.Select(s => new TariffSlabDto
            {
                TariffSlabId = s.TariffSlabId,
                TariffId = s.TariffId,
                FromKwh = s.FromKwh,
                ToKwh = s.ToKwh,
                RatePerKwh = s.RatePerKwh
            });

            return Ok(slabDtos);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TariffSlabDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var slab = new TariffSlab
            {
                TariffId = dto.TariffId,
                FromKwh = dto.FromKwh,
                ToKwh = dto.ToKwh,
                RatePerKwh = dto.RatePerKwh
            };

            await _tariffSlabRepository.AddAsync(slab);
            await _tariffSlabRepository.SaveAsync();

            dto.TariffSlabId = slab.TariffSlabId;
            return CreatedAtAction(nameof(GetByTariffId), new { tariffId = dto.TariffId }, dto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TariffSlabDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            if (id != dto.TariffSlabId)
                return BadRequest("Mismatched slab ID.");

            var existingSlab = await _tariffSlabRepository.GetByIdAsync(id);
            if (existingSlab == null)
                return NotFound();

            existingSlab.FromKwh = dto.FromKwh;
            existingSlab.ToKwh = dto.ToKwh;
            existingSlab.RatePerKwh = dto.RatePerKwh;

            _tariffSlabRepository.Update(existingSlab);
            await _tariffSlabRepository.SaveAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var slab = await _tariffSlabRepository.GetByIdAsync(id);
            if (slab == null)
                return NotFound();

            _tariffSlabRepository.Delete(slab);
            await _tariffSlabRepository.SaveAsync();

            return NoContent();
        }
    }
}
