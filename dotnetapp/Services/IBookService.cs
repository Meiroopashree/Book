using System.Collections.Generic;

namespace.dotnetapp.Services
{
public interface IBookService
{
    List<Book> GetBooks();
    Book GetBook(int id);
    void SaveBook(Book book);
    void UpdateBook(int id, Book book);
    void DeleteBook(int id);
}
}