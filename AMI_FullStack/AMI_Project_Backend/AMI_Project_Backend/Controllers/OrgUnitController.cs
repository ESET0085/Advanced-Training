using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class OrgUnitController : ControllerBase
    {
        private readonly IOrgUnitRepository _orgUnitRepository;
        private readonly ILogger<OrgUnitController> _logger;

        public OrgUnitController(IOrgUnitRepository orgUnitRepository, ILogger<OrgUnitController> logger)
        {
            _orgUnitRepository = orgUnitRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgUnitDto>>> GetAll()
        {
            var orgUnits = await _orgUnitRepository.GetAllAsync();
            var dtoList = orgUnits.Select(o => new OrgUnitDto
            {
                OrgUnitId = o.OrgUnitId,
                Type = o.Type,
                Name = o.Name,
                ParentId = o.ParentId
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgUnitDto>> GetById(int id)
        {
            var orgUnit = await _orgUnitRepository.GetByIdAsync(id);
            if (orgUnit == null)
                return NotFound();

            var dto = new OrgUnitDto
            {
                OrgUnitId = orgUnit.OrgUnitId,
                Type = orgUnit.Type,
                Name = orgUnit.Name,
                ParentId = orgUnit.ParentId
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrgUnitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (dto.ParentId.HasValue)
                {
                    var parentExists = await _orgUnitRepository.GetByIdAsync(dto.ParentId.Value);
                    if (parentExists == null)
                        return BadRequest("Invalid ParentId. Parent OrgUnit not found.");
                }

                var orgUnit = new OrgUnit
                {
                    Type = dto.Type,
                    Name = dto.Name,
                    ParentId = dto.ParentId
                };

                await _orgUnitRepository.AddAsync(orgUnit);
                await _orgUnitRepository.SaveChangesAsync();

                var createdDto = new OrgUnitDto
                {
                    OrgUnitId = orgUnit.OrgUnitId,
                    Type = orgUnit.Type,
                    Name = orgUnit.Name,
                    ParentId = orgUnit.ParentId
                };

                return CreatedAtAction(nameof(GetById), new { id = orgUnit.OrgUnitId }, createdDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating OrgUnit");
                return StatusCode(500, "An error occurred while creating OrgUnit.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrgUnitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orgUnit = await _orgUnitRepository.GetByIdAsync(id);
            if (orgUnit == null)
                return NotFound();

            orgUnit.Type = dto.Type;
            orgUnit.Name = dto.Name;
            orgUnit.ParentId = dto.ParentId;

            try
            {
                await _orgUnitRepository.UpdateAsync(orgUnit);
                await _orgUnitRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating OrgUnit {Id}", id);
                return StatusCode(500, "An error occurred while updating OrgUnit.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orgUnitRepository.DeleteAsync(id);
                await _orgUnitRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting OrgUnit {Id}", id);
                return StatusCode(500, "An error occurred while deleting OrgUnit.");
            }
        }
    }
}
