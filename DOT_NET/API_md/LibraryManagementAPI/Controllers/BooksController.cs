using LibraryManagementAPI.Model;
using LibraryManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        
        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }


        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepo.GetAllAsync();
            return Ok(books);
        }






        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _bookRepo.GetByIdAsync(id);
            if (books == null)
                return NotFound();
            return Ok(books);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            var newBook = await _bookRepo.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = newBook.BookId }, newBook);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Book book)
        {
            if (id != book.BookId)
                return BadRequest("Book ID mismatch");

            var updatedBook = await _bookRepo.UpdateAsync(book);
            return Ok(updatedBook);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookRepo.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
