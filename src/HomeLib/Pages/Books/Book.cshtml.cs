using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages.Books;

public class Book : PageModel
{
    public IReadOnlyCollection<ReadBook> Books { get; } =
        [
            new ReadBook
            {
                Id = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                IsRead = true,
                Rating = 5,
                Notes = "A great American novel.",
            },
            new ReadBook
            {
                Id = 2,
                Title = "Mobile First",
                Author = "Luke Wroblewski",
                IsRead = true,
                Rating = 4,
                Notes = "A must-read for web designers.",
            },
            new ReadBook
            {
                Id = 3,
                Title = "The Art of War",
                Author = "Sun Tzu",
                IsRead = false,
                Rating = 3,
                Notes = "A classic book on military strategy.",
            },
        ];

    public required ReadBook CurrentBook { get; set; }

    public IActionResult OnGet(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book is not null)
        {
            CurrentBook = book;
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
        public required string Notes { get; set; }
    }
}
