using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeterController : ControllerBase
    {
        private readonly IMeterRepository _meterRepo;

        public MeterController(IMeterRepository meterRepo)
        {
            _meterRepo = meterRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meters = await _meterRepo.GetAllAsync();
            return Ok(meters.Select(MeterDto.FromMeter));
        }

        [HttpGet("{serialNo}")]
        public async Task<IActionResult> Get(string serialNo)
        {
            var meter = await _meterRepo.GetBySerialAsync(serialNo);
            if (meter == null)
                return NotFound(new { message = "Meter not found." });

            return Ok(MeterDto.FromMeter(meter));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MeterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // ---- Duplicate checks ----
            if (await _meterRepo.GetBySerialAsync(dto.SerialNo) != null)
                return BadRequest(new { message = "Meter Serial Number already exists." });

            if (await _meterRepo.ExistsIpAsync(dto.IpAddress))
                return BadRequest(new { message = "IP Address already exists." });

            if (await _meterRepo.ExistsIccidAsync(dto.Iccid))
                return BadRequest(new { message = "ICCID already exists." });

            if (await _meterRepo.ExistsImsiAsync(dto.Imsi))
                return BadRequest(new { message = "IMSI already exists." });

            var meter = dto.ToMeter();
            await _meterRepo.AddAsync(meter);
            await _meterRepo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { serialNo = meter.MeterSerialNo }, MeterDto.FromMeter(meter));
        }

        [HttpPut("{serialNo}")]
        public async Task<IActionResult> Update(string serialNo, [FromBody] MeterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var meter = await _meterRepo.GetBySerialAsync(serialNo);
            if (meter == null)
                return NotFound(new { message = "Meter not found." });

            // Debug logging
            Console.WriteLine($"Updating meter: {serialNo}");
            Console.WriteLine($"Checking IP: {dto.IpAddress}, ICCID: {dto.Iccid}, IMSI: {dto.Imsi}");

            // These checks should exclude the current meter
            var ipExists = await _meterRepo.ExistsIpAsync(dto.IpAddress, serialNo);
            //var iccidExists = await _meterRepo.ExistsIccidAsync(dto.Iccid, serialNo);
            //var imsiExists = await _meterRepo.ExistsImsiAsync(dto.Imsi, serialNo);

            //Console.WriteLine($"Duplicate check results - IP: {ipExists}, ICCID: {iccidExists}, IMSI: {imsiExists}");

            if (ipExists)
                return BadRequest(new { message = "IP Address already exists." });

            //if (iccidExists)
            //    return BadRequest(new { message = "ICCID already exists." });

            //if (imsiExists)
            //    return BadRequest(new { message = "IMSI already exists." });

            dto.UpdateMeter(meter);
            _meterRepo.Update(meter);
            await _meterRepo.SaveAsync();

            return Ok(MeterDto.FromMeter(meter));
        }

        [HttpDelete("{serialNo}")]
        public async Task<IActionResult> Delete(string serialNo)
        {
            var meter = await _meterRepo.GetBySerialAsync(serialNo);
            if (meter == null)
                return NotFound(new { message = "Meter not found." });

            _meterRepo.Delete(meter);
            await _meterRepo.SaveAsync();

            return NoContent();
        }

        [HttpGet("by-consumer/{consumerId}")]
        public async Task<IActionResult> GetByConsumer(long consumerId)
        {
            var meters = await _meterRepo.FindByConsumerIdAsync(consumerId);
            return Ok(meters.Select(MeterDto.FromMeter)); // returns empty list if none
        }
    }
}
