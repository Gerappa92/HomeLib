using System.ComponentModel.DataAnnotations;
using HomeLib.DataAccess.Book;
using HomeLib.DataAccess.Book.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Riok.Mapperly.Abstractions;

namespace HomeLib.Pages.Books;

public class NewBook(ILogger<NewBook> logger, IBookService bookService) : PageModel
{
    private readonly ILogger<NewBook> _logger = logger;

    [BindProperty]
    public required InputBook Book { get; set; }

    public void OnGet()
    {
        // Code to handle GET requests
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid input: {@Book}", Book);
            return Page();
        }

        var newBook = Book.MapToAddBookCommand();
        await bookService.AddBook(newBook);

        return RedirectToPage(
            nameof(NewBookConfirmation),
            new { title = Book.Title, author = Book.Author }
        );
    }

    public class InputBook
    {
        [Required]
        [MinLength(3)]
        public required string Title { get; set; }

        [Required]
        [MinLength(3)]
        public required string Author { get; set; }
    }
}

[Mapper]
public static partial class InputBookMapping
{
    public static partial AddBookCommand MapToAddBookCommand(this NewBook.InputBook book);
}
