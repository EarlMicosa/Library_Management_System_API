using System.Collections.Generic;
using System.Linq;

public class LibraryManager
{
    private List<Book> books = new List<Book>();
    private int nextId = 1;

    public Book AddBook(Book book)
    {
        book.Id = nextId++;
        books.Add(book);
        return book;
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public Book GetBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public Book UpdateBook(int id, Book updatedBook)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.IsAvailable = updatedBook.IsAvailable;
        }
        return book;
    }

    public bool DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            books.Remove(book);
            return true;
        }
        return false;
    }
}
