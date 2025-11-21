using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerRepository _consumerRepository;
        private readonly IMapper _mapper;

        public ConsumerController(IConsumerRepository consumerRepository, IMapper mapper)
        {
            _consumerRepository = consumerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consumers = await _consumerRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ConsumerDto>>(consumers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var consumer = await _consumerRepository.GetByIdAsync(id);
            if (consumer == null) return NotFound();
            return Ok(_mapper.Map<ConsumerDto>(consumer));
        }

        [HttpGet("get-id-by-email/{email}")]
public async Task<IActionResult> GetConsumerIdByEmail(string email)
{
    var consumer = await _consumerRepository.GetAllAsync();
    var found = consumer.FirstOrDefault(c => c.Email == email);

    if (found == null)
        return NotFound("Consumer not found");

    return Ok(found.ConsumerId);
}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConsumerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var consumers = await _consumerRepository.GetAllAsync();

                // 🔹 Check for duplicate Email
                if (!string.IsNullOrWhiteSpace(dto.Email) &&
                    consumers.Any(c => c.Email != null && c.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    return Conflict(new { message = "Email already exists." });
                }

                // 🔹 Check for duplicate Phone
                if (!string.IsNullOrWhiteSpace(dto.Phone) &&
                    consumers.Any(c => c.Phone != null && c.Phone.Equals(dto.Phone, StringComparison.OrdinalIgnoreCase)))
                {
                    return Conflict(new { message = "Phone number already exists." });
                }

                var consumer = _mapper.Map<Consumer>(dto);
                consumer.CreatedAt = DateTime.UtcNow;
                await _consumerRepository.AddAsync(consumer);
                await _consumerRepository.SaveAsync();

                return CreatedAtAction(nameof(GetById), new { id = consumer.ConsumerId }, _mapper.Map<ConsumerDto>(consumer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the consumer",
                    detail = ex.InnerException?.Message ?? ex.Message
                });
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ConsumerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _consumerRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var consumers = await _consumerRepository.GetAllAsync();

            // 🔹 Duplicate email check (exclude self)
            if (!string.IsNullOrWhiteSpace(dto.Email) &&
                consumers.Any(c => c.ConsumerId != id && c.Email != null && c.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict(new { message = "Email already exists." });
            }

            // 🔹 Duplicate phone check (exclude self)
            if (!string.IsNullOrWhiteSpace(dto.Phone) &&
                consumers.Any(c => c.ConsumerId != id && c.Phone != null && c.Phone.Equals(dto.Phone, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict(new { message = "Phone number already exists." });
            }

            _mapper.Map(dto, existing);
            existing.UpdatedAt = DateTime.UtcNow;

            _consumerRepository.Update(existing);
            await _consumerRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var consumer = await _consumerRepository.GetByIdAsync(id);
            if (consumer == null) return NotFound();

            _consumerRepository.Delete(consumer);
            await _consumerRepository.SaveAsync();
            return NoContent();
        }
    }
}
