using LibraryManagementAPI.Model;
using LibraryManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        
        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepo.GetAllAsync();
            return Ok(authors);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            if (author == null)
                return BadRequest();

            var newAuthor = await _authorRepo.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = newAuthor.AuthorId }, newAuthor);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Author author)
        {
            if (id != author.AuthorId)
                return BadRequest("Author ID mismatch");

            var updated = await _authorRepo.UpdateAsync(author);
            return Ok(updated);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _authorRepo.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
