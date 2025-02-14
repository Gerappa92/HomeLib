using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages.Books;

public class NewBook(ILogger<NewBook> logger) : PageModel
{
    private readonly ILogger<NewBook> _logger = logger;

    [BindProperty]
    public required InputBook Book { get; set; }

    public void OnGet()
    {
        // Code to handle GET requests
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid input: {@Book}", Book);
            return Page();
        }

        _logger.LogInformation("New book: {@Book}", Book);
        // Code to handle POST requests, e.g., save the new book details

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
