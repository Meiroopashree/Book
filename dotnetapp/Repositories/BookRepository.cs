using System.Collections.Generic;

namespace dotnetapp.Repositories
{

public class BookRepository
{
    private List<Book> books = new List<Book>();

    public List<Book> GetBooks() => books;

    public Book GetBook(int id) => books.Find(b => b.BookId == id);

    public void SaveBook(Book book) => books.Add(book);

    public void UpdateBook(int id, Book book)
    {
        var existingBook = books.Find(b => b.BookId == id);
        if (existingBook != null)
        {
            existingBook.BookName = book.BookName;
            existingBook.Category = book.Category;
            existingBook.Price = book.Price;
        }
    }

    public void DeleteBook(int id) => books.RemoveAll(b => b.BookId == id);
}
}
