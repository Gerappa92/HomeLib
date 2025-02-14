using HomeLib.BusinessLogic.Commands.Books;
using HomeLib.BusinessLogic.Queries.Books;

namespace HomeLib.BusinessLogic;

public interface IBookService
{
    Task AddBook(AddBookCommand book);
    Task DeleteBook(int id);
    Task<BookDetails?> GetBook(int id);
    Task<IEnumerable<BookCollectionItem>> GetBooks();
    Task UpdateBook(UpdateBookCommand book);
}
