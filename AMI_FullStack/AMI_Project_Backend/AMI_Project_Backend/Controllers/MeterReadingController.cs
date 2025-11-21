using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingRepository _meterReadingRepository;

        public MeterReadingController(IMeterReadingRepository meterReadingRepository)
        {
            _meterReadingRepository = meterReadingRepository;
        }

        // GET: api/meterreading
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var readings = await _meterReadingRepository.GetAllWithMetersAsync();

            // Map with ConsumerId from related Meter
            var result = readings.Select(r => new
            {
                r.ReadingId,
                r.MeterSerialNo,
                ConsumerId = r.MeterSerialNoNavigation?.ConsumerId ?? 0, // 👈 Safe access
                r.ReadingDate,
                r.Kwh,
                r.CreatedAt
            });

            return Ok(result);
        }

        // GET: api/meterreading/mtr001
        [HttpGet("{meterSerialNo}")]
        public async Task<IActionResult> GetByMeter(string meterSerialNo)
        {
            var readings = await _meterReadingRepository.GetByMeterSerialNoAsync(meterSerialNo);
            if (!readings.Any())
                return NotFound($"No readings found for meter {meterSerialNo}");

            var result = readings.Select(r => new
            {
                r.ReadingId,
                r.MeterSerialNo,
                ConsumerId = r.MeterSerialNoNavigation?.ConsumerId ?? 0,
                r.ReadingDate,
                r.Kwh,
                r.CreatedAt
            });

            return Ok(result);
        }

        // GET: api/meterreading/mtr001/range?startDate=2025-11-08&endDate=2025-11-10
        [HttpGet("{meterSerialNo}/range")]
        public async Task<IActionResult> GetByDateRange(string meterSerialNo, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var readings = await _meterReadingRepository.GetByDateRangeAsync(meterSerialNo, startDate, endDate);
            if (!readings.Any())
                return NotFound($"No readings found for meter {meterSerialNo} between {startDate} and {endDate}");

            var result = readings.Select(r => new
            {
                r.ReadingId,
                r.MeterSerialNo,
                ConsumerId = r.MeterSerialNoNavigation?.ConsumerId ?? 0,
                r.ReadingDate,
                r.Kwh,
                r.CreatedAt
            });

            return Ok(result);
        }

        // POST: api/meterreading
        [HttpPost]
        public async Task<IActionResult> AddReading([FromBody] MeterReadingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // ✅ Check duplicate for the same meter & date
            var readings = await _meterReadingRepository.GetAllWithMetersAsync();
            var existing = readings.Where(
                r => r.MeterSerialNo == dto.MeterSerialNo &&
                     r.ReadingDate.Date == dto.ReadingDate.Date
            );

            if (existing.Any())
                return Conflict($"Reading for meter '{dto.MeterSerialNo}' already exists on {dto.ReadingDate:yyyy-MM-dd}");

            var entity = new MeterReading
            {
                MeterSerialNo = dto.MeterSerialNo,
                ReadingDate = dto.ReadingDate,
                Kwh = dto.Kwh,
                CreatedAt = DateTime.UtcNow
            };

            await _meterReadingRepository.AddAsync(entity);
            await _meterReadingRepository.SaveChangesAsync();

            return Ok("Meter reading added successfully.");
        }


        // POST: api/meterreading/bulk
        [HttpPost("bulk")]
        public async Task<IActionResult> AddBulk([FromBody] IEnumerable<MeterReadingDto> readings)
        {
            if (readings == null || !readings.Any())
                return BadRequest("No readings provided.");

            var validReadings = new List<MeterReading>();
            var duplicates = new List<string>();

            // Get all existing readings with meters to check for duplicates
            var allReadings = await _meterReadingRepository.GetAllWithMetersAsync();

            foreach (var dto in readings)
            {
                if (dto == null || string.IsNullOrWhiteSpace(dto.MeterSerialNo)) continue;

                var existing = allReadings.Where(
                    r => r.MeterSerialNo == dto.MeterSerialNo &&
                         r.ReadingDate.Date == dto.ReadingDate.Date
                );

                if (existing.Any())
                {
                    duplicates.Add($"{dto.MeterSerialNo} ({dto.ReadingDate:yyyy-MM-dd})");
                    continue;
                }

                validReadings.Add(new MeterReading
                {
                    MeterSerialNo = dto.MeterSerialNo,
                    ReadingDate = dto.ReadingDate,
                    Kwh = dto.Kwh,
                    CreatedAt = DateTime.UtcNow
                });
            }

            if (validReadings.Any())
                await _meterReadingRepository.AddBulkAsync(validReadings);

            var message = $"{validReadings.Count} readings inserted successfully.";
            if (duplicates.Any())
                message += $" Skipped duplicates: {string.Join(", ", duplicates)}";

            return Ok(message);
        }

    }
}
