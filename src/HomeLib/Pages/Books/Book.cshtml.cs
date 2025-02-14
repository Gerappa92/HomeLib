using System.Threading.Tasks;
using HomeLib.BusinessLogic;
using HomeLib.BusinessLogic.Queries.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Riok.Mapperly.Abstractions;

namespace HomeLib.Pages.Books;

public class Book(ILogger<Book> logger, IBookService bookService) : PageModel
{
    public required ReadBook CurrentBook { get; set; }

    public async Task<IActionResult> OnGet(int id)
    {
        var book = await bookService.GetBook(id);
        if (book is not null)
        {
            CurrentBook = book.MapToReadBook();
        }
        else
        {
            return NotFound();
        }
        return Page();
    }

    public class ReadBook
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required bool IsRead { get; set; }
        public required int Rating { get; set; }
        public string? Notes { get; set; }
    }
}

[Mapper]
public static partial class ReadBookMapping
{
    public static partial Book.ReadBook MapToReadBook(this BookDetails book);
}
