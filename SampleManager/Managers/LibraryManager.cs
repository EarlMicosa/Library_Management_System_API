using System.Collections.Generic;
using System.Linq;
using SampleModels; // Include the namespace for Book

public class LibraryManager
{
    private List<LibraryModel.Book> books = new List<LibraryModel.Book>();
    private int nextId = 1;

    public LibraryModel.Book AddBook(LibraryModel.Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        book.Id = nextId++;
        books.Add(book);
        return book;
    }

    public List<LibraryModel.Book> GetAllBooks()
    {
        return books;
    }

    public LibraryModel.Book GetBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public LibraryModel.Book UpdateBook(int id, LibraryModel.Book updatedBook)
    {
        if (updatedBook == null) throw new ArgumentNullException(nameof(updatedBook));
        var book = GetBookById(id);
        if (book != null)
        {
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.IsAvailable = updatedBook.IsAvailable;
            return book;
        }
        return null; // Or throw an exception
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
