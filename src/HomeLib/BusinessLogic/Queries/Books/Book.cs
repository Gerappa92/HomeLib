namespace HomeLib.BusinessLogic.Queries.Books
{
    public abstract class Book
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required bool IsRead { get; set; }
        public required int Rating { get; set; }
    }
}
