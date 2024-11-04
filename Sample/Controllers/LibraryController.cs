using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryManager _libraryManager;

        public LibraryController()
        {
            _libraryManager = new LibraryManager();
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _libraryManager.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _libraryManager.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var addedBook = _libraryManager.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null)
            {
                return BadRequest();
            }
            var book = _libraryManager.UpdateBook(id, updatedBook);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            if (!_libraryManager.DeleteBook(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
