using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SampleModels;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryManager _libraryManager;

     
        public LibraryController(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        [HttpGet]
        public ActionResult<List<LibraryModel.Book>> GetBooks()
        {
            var books = _libraryManager.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryModel.Book> GetBook(int id)
        {
            var book = _libraryManager.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<LibraryModel.Book> AddBook([FromBody] LibraryModel.Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var addedBook = _libraryManager.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public ActionResult<LibraryModel.Book> UpdateBook(int id, [FromBody] LibraryModel.Book updatedBook)
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
