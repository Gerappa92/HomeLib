using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages.Books;

public class NewBookConfirmation(ILogger<NewBookConfirmation> logger) : PageModel
{
    private readonly ILogger<NewBookConfirmation> _logger = logger;

    public required string Title { get; set; }
    public required string Author { get; set; }

    public void OnGet(string title, string author)
    {
        Title = title;
        Author = author;
    }
}
