using System.Collections.Generic;

namespace.dotnetapp.Services
{
public class BookService : IBookService
{
    private readonly BookRepository _repository;

    public BookService(BookRepository repository)
    {
        _repository = repository;
    }

    public List<Book> GetBooks() => _repository.GetBooks();

    public Book GetBook(int id) => _repository.GetBook(id);

    public void SaveBook(Book book) => _repository.SaveBook(book);

    public void UpdateBook(int id, Book book) => _repository.UpdateBook(id, book);

    public void DeleteBook(int id) => _repository.DeleteBook(id);
}
}
