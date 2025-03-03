namespace HomeLib.DataAccess.Book;

public class BookEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public bool IsRead { get; set; }
    public int Rating { get; set; }
    public string? Notes { get; set; }
    public bool IsCurrentlyReading { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateRead { get; set; }
}
