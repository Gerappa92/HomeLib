using HomeLib.DataAccess.Book.Commands;
using HomeLib.DataAccess.Book.Queries;

namespace HomeLib.DataAccess.Book;

public interface IBookService
{
    Task AddBook(AddBookCommand book);
    Task DeleteBook(int id);
    Task<BookDetails?> GetBook(int id);
    Task<IEnumerable<BookCollectionItem>> GetBooks();
    Task UpdateBook(UpdateBookCommand book);
}
