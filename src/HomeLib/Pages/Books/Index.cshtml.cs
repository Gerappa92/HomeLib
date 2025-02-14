using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages.Books;

public class Index(ILogger<Index> logger) : PageModel
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
            },
            new ReadBook
            {
                Id = 2,
                Title = "Mobile First",
                Author = "Luke Wroblewski",
                IsRead = true,
                Rating = 4,
            },
            new ReadBook
            {
                Id = 3,
                Title = "The Art of War",
                Author = "Sun Tzu",
                IsRead = false,
                Rating = 3,
            },
        ];
    private readonly ILogger<Index> _logger = logger;

    public required string Title { get; set; }
    public required string Author { get; set; }

    public void OnGet() { }

    public class ReadBook
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required bool IsRead { get; set; }
        public required int Rating { get; set; }
    }
}
