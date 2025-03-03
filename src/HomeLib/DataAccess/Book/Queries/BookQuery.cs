namespace HomeLib.DataAccess.Book.Queries
{
    public abstract class BookQuery
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required bool IsRead { get; set; }
        public required int Rating { get; set; }
    }
}
