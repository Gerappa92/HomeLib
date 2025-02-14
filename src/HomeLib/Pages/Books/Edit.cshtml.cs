using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages.Books;

public class Edit(ILogger<Edit> logger) : PageModel
{
    private readonly ILogger<Edit> _logger = logger;

    [BindProperty]
    public required EditBook Book { get; set; }

    public void OnGet(int id)
    {
        _logger.LogInformation("Edit book with id {id}", id);
        Book = new EditBook
        {
            Id = id,
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
        };
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _logger.LogInformation("Edit book with id {id}", Book.Id);
        return RedirectToPage(nameof(Book), new { id = Book.Id });
    }

    public class EditBook
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
