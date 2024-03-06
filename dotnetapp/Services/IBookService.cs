using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
public interface IBookService
{
    List<Book> GetBooks();
    Book GetBook(int id);
    void SaveBook(Book book);
    void UpdateBook(int id, Book book);
    bool DeleteBook(int id);
}

}