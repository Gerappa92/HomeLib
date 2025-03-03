using HomeLib.DataAccess.Book;
using HomeLib.DataAccess.Book.Queries;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Riok.Mapperly.Abstractions;

namespace HomeLib.Pages.Books;

public class Index(ILogger<Index> logger, IBookService bookService) : PageModel
{
    public List<ReadBookItem> Books { get; set; } = [];
    private readonly ILogger<Index> _logger = logger;

    public required string Title { get; set; }
    public required string Author { get; set; }

    public async Task OnGet()
    {
        var books = await bookService.GetBooks();
        Books = [.. books.Select(b => b.MapToReadBookItem())];
    }

    public class ReadBookItem
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required bool IsRead { get; set; }
        public required int Rating { get; set; }
    }
}

[Mapper]
public static partial class ReadBookItemMapping
{
    public static partial Index.ReadBookItem MapToReadBookItem(this BookCollectionItem book);
}
