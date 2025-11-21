using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffController : ControllerBase
    {
        private readonly ITariffRepository _tariffRepo;

        public TariffController(ITariffRepository tariffRepo)
        {
            _tariffRepo = tariffRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tariffs = await _tariffRepo.GetAllAsync();
            var dtoList = tariffs.Select(t => new TariffDto
            {
                TariffId = t.TariffId,
                Name = t.Name,
                EffectiveFrom = t.EffectiveFrom,
                EffectiveTo = t.EffectiveTo,
                BaseRate = t.BaseRate,
                TaxRate = t.TaxRate
            });
            return Ok(dtoList);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tariff = await _tariffRepo.GetByIdAsync(id);
            if (tariff == null) return NotFound();

            var dto = new TariffDto
            {
                TariffId = tariff.TariffId,
                Name = tariff.Name,
                EffectiveFrom = tariff.EffectiveFrom,
                EffectiveTo = tariff.EffectiveTo,
                BaseRate = tariff.BaseRate,
                TaxRate = tariff.TaxRate
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TariffDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var effectiveFrom = DateOnly.FromDateTime(DateTime.UtcNow);

            var tariff = new Tariff
            {
                Name = dto.Name,
                EffectiveFrom = effectiveFrom,
                EffectiveTo = dto.EffectiveTo,
                BaseRate = dto.BaseRate,
                TaxRate = dto.TaxRate
            };

            var created = await _tariffRepo.AddAsync(tariff);
            dto.TariffId = created.TariffId;
            dto.EffectiveFrom = tariff.EffectiveFrom;

            return CreatedAtAction(nameof(GetById), new { id = created.TariffId }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TariffDto dto)
        {
            if (id != dto.TariffId)
                return BadRequest("Mismatched Tariff ID");

            var existing = await _tariffRepo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.EffectiveTo = dto.EffectiveTo;
            existing.BaseRate = dto.BaseRate;
            existing.TaxRate = dto.TaxRate;

            var updated = await _tariffRepo.UpdateAsync(existing);
            if (updated == null)
                return NotFound();

            dto.EffectiveFrom = existing.EffectiveFrom;
            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _tariffRepo.DeleteAsync(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                // Friendly error message when FK prevents deletion
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{tariffId:int}/slabs")]
        public async Task<IActionResult> GetSlabs(int tariffId)
        {
            var slabs = await _tariffRepo.GetSlabsByTariffIdAsync(tariffId);
            return Ok(slabs);
        }
    }
}
