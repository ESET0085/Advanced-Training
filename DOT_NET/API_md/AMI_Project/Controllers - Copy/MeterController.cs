using AMI_Project.Models;
using AMI_Project_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Meter
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meters = await _unitOfWork.Meters.GetAllAsync();
            return Ok(meters);
        }

        // GET: api/Meter/{serialNo}
        [HttpGet("{serialNo}")]
        public async Task<IActionResult> GetById(string serialNo)
        {
            var meter = await _unitOfWork.Meters.GetByIdAsync(serialNo);
            if (meter == null) return NotFound();
            return Ok(meter);
        }

        // POST: api/Meter
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Meter meter)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _unitOfWork.Meters.AddAsync(meter);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { serialNo = meter.MeterSerialNo }, meter);
        }

        // PUT: api/Meter/{serialNo}
        [HttpPut("{serialNo}")]
        [Authorize]
        public async Task<IActionResult> Update(string serialNo, [FromBody] Meter meter)
        {
            if (serialNo != meter.MeterSerialNo)
                return BadRequest("Serial number mismatch");

            var existing = await _unitOfWork.Meters.GetByIdAsync(serialNo);
            if (existing == null) return NotFound();

            _unitOfWork.Meters.Update(meter);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Meter/{serialNo}
        [HttpDelete("{serialNo}")]
        [Authorize]
        public async Task<IActionResult> Delete(string serialNo)
        {
            var existing = await _unitOfWork.Meters.GetByIdAsync(serialNo);
            if (existing == null) return NotFound();

            _unitOfWork.Meters.Delete(existing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
