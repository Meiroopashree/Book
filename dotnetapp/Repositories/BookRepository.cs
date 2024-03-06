using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{

// BookRepository.cs
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

public class BookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Book> GetBooks() => _context.Books.ToList();

    public Book GetBook(int id) => _context.Books.Find(id);

    public void SaveBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(int id, Book book)
    {
        var existingBook = _context.Books.Find(id);
        if (existingBook != null)
        {
            existingBook.BookName = book.BookName;
            existingBook.Category = book.Category;
            existingBook.Price = book.Price;
            _context.SaveChanges();
        }
    }

    public bool DeleteBook(int id)
    {
        var bookToRemove = _context.Books.Find(id);
        if (bookToRemove != null)
        {
            _context.Books.Remove(bookToRemove);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}

}
