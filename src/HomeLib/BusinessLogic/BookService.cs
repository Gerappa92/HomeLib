using System.Threading.Tasks;
using HomeLib.BusinessLogic.Commands.Books;
using HomeLib.BusinessLogic.Mappings;
using HomeLib.BusinessLogic.Queries.Books;
using HomeLib.DataAcces;
using Microsoft.EntityFrameworkCore;

namespace HomeLib.BusinessLogic;

public class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly WebAppDbContext _dbContext;

    public BookService(ILogger<BookService> logger, WebAppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task AddBook(AddBookCommand book)
    {
        var entity = book.MapToBookEntity();
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBook(UpdateBookCommand book)
    {
        var entity = book.MapToBookEntity();
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBook(int id)
    {
        _dbContext.Remove(id);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<BookDetails?> GetBook(int id)
    {
        var entity = await _dbContext.Books.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        var book = entity.MapToBookDetails();
        return book;
    }

    public async Task<IEnumerable<BookCollectionItem>> GetBooks()
    {
        var entities = await _dbContext.Books.ToListAsync();
        var books = entities.Select(e => e.MapToBookCollectionItem());
        return books;
    }
}
