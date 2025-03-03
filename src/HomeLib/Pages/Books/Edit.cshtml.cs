using HomeLib.DataAccess.Book;
using HomeLib.DataAccess.Book.Commands;
using HomeLib.DataAccess.Book.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Riok.Mapperly.Abstractions;

namespace HomeLib.Pages.Books;

public class Edit(ILogger<Edit> logger, IBookService bookService) : PageModel
{
    private readonly ILogger<Edit> _logger = logger;

    [BindProperty]
    public required EditBook Book { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await bookService.GetBook(id);
        if (book is null)
        {
            return NotFound();
        }
        Book = book.MapToEditBook();
        return Page();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var book = Book.MapToEditBookCommand(id);
        await bookService.UpdateBook(book);
        return RedirectToPage(nameof(Book), new { id });
    }

    public class EditBook
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}

[Mapper]
public static partial class EditBookMapping
{
    public static partial Edit.EditBook MapToEditBook(this BookDetails book);

    public static partial UpdateBookCommand MapToEditBookCommand(this Edit.EditBook book);

    public static UpdateBookCommand MapToEditBookCommand(this Edit.EditBook book, int id)
    {
        var bookMapped = book.MapToEditBookCommand();
        bookMapped.Id = id;
        return bookMapped;
    }
}
