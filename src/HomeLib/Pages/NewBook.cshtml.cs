using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages;

public class NewBookModel : PageModel
{
    private readonly ILogger<NewBookModel> _logger;

    public NewBookModel(ILogger<NewBookModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public InputBook Book { get; set; }

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

        return RedirectToPage("/Index");
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