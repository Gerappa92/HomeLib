namespace HomeLib.DataAcces.Entities;

public class BookEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public bool IsRead { get; set; }
    public int Rating { get; set; }
    public string? Notes { get; set; }
}
